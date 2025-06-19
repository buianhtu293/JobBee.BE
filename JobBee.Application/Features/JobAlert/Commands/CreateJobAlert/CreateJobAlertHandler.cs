using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.EmailService;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobAlert.Commands.CreateJobAlert
{
	public class CreateJobAlertHandler : IRequestHandler<CreateJobAlertCommand, ApiResponse<CreateJobAlertDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobAlertRepository _jobAlertRepository;
		private readonly IUserRepository _userRepository;
		private readonly IJobRepository _jobRepository;
		private readonly IEmailService _emailService;
		private readonly IUnitOfWork<Domain.Entities.JobAlert, Guid> _unitOfWork;

		public CreateJobAlertHandler(IMapper mapper,
			IJobAlertRepository jobAlertRepository,
			IUserRepository userRepository,
			IJobRepository jobRepository,
			IEmailService emailService,
			IUnitOfWork<Domain.Entities.JobAlert, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobAlertRepository = jobAlertRepository;
			_userRepository = userRepository;
			_jobRepository = jobRepository;
			_emailService = emailService;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateJobAlertDto>> Handle(CreateJobAlertCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateJobAlertValidator(_jobAlertRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Alert", validatorResult);
			}

			var userOpentoWork = await _userRepository.GetUserOpenToWork();

			var jobAlertToCreate = _mapper.Map<Domain.Entities.JobAlert>(request);

			// Prepare email content
			string subject = $"New Job Alert: {request.AlertName ?? "A job matching your interest"}";

			var jobNeedToAlert = _jobRepository.GetById(request.JobId);

			// Send emails
			foreach (var user in userOpentoWork)
			{

				jobAlertToCreate.Id = Guid.NewGuid();
				jobAlertToCreate.CandidateId = user.Candidate.Id;
				jobAlertToCreate.IsActive = true;
				jobAlertToCreate.CreatedAt = DateTime.Now;

				_jobAlertRepository.Insert(jobAlertToCreate);

				if (!string.IsNullOrEmpty(user.Email))
				{
					await _emailService.SendEmailJobAlert(user.Email, subject, jobNeedToAlert);
				}
			}

			var jobAlertCreated = _mapper.Map<CreateJobAlertDto>(jobAlertToCreate);
			var data = new ApiResponse<CreateJobAlertDto>("Success", 200, jobAlertCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
