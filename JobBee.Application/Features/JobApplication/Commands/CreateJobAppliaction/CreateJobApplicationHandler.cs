using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction
{
	public class CreateJobApplicationHandler : IRequestHandler<CreateJobApplicationCommand, ApiResponse<CreateJobApplicationDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IUnitOfWork<Domain.Entities.JobApplication, Guid> _unitOfWork;

		public CreateJobApplicationHandler(IMapper mapper, 
			IJobApplicationRepository jobApplicationRepository, 
			IUnitOfWork<Domain.Entities.JobApplication, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobApplicationRepository = jobApplicationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateJobApplicationDto>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateJobApplicationValidator(_jobApplicationRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Application", validatorResult);
			}

			var jobApplicatonToCreate = _mapper.Map<Domain.Entities.JobApplication>(request);
			jobApplicatonToCreate.Id = Guid.NewGuid();
			jobApplicatonToCreate.AppliedAt = DateTime.Now;
			jobApplicatonToCreate.UpdatedAt = DateTime.Now;

			_jobApplicationRepository.Insert(jobApplicatonToCreate);

			var jobApplicationCreated = _mapper.Map<CreateJobApplicationDto>(jobApplicatonToCreate);
			var data = new ApiResponse<CreateJobApplicationDto>("Success", 200, jobApplicationCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
