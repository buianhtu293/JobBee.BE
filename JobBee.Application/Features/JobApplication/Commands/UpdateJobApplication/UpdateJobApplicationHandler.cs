using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Commands.UpdateJobApplication
{
	public class UpdateJobApplicationHandler : IRequestHandler<UpdateJobApplicationCommand, ApiResponse<UpdateJobApplicationDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IUnitOfWork<Domain.Entities.JobApplication, Guid> _unitOfWork;

		public UpdateJobApplicationHandler(IMapper mapper,
			IJobApplicationRepository jobApplicationRepository,
			IUnitOfWork<Domain.Entities.JobApplication, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobApplicationRepository = jobApplicationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateJobApplicationDto>> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateJobApplicationValidator(_jobApplicationRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Application", validatorResult);
			}

			var jobApplication = _jobApplicationRepository.GetById(request.Id);

			if (jobApplication == null)
			{
				throw new NotFoundException(nameof(jobApplication), request.Id);
			}

			var jobApplicationToUpdate = _mapper.Map<Domain.Entities.JobApplication>(jobApplication);
			jobApplicationToUpdate.Status = request.Status;

			_jobApplicationRepository.Update(jobApplicationToUpdate);

			var jobApplicationUpdated = _mapper.Map<UpdateJobApplicationDto>(jobApplicationToUpdate);
			var data = new ApiResponse<UpdateJobApplicationDto>("Success", 200, jobApplicationUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
