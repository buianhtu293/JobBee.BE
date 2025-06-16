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

namespace JobBee.Application.Features.JobType.Commands.CreateJobType
{
	public class CreateJobTypeHandler : IRequestHandler<CreateJobTypeCommand, ApiResponse<CreateJobTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobTypeRepository _jobTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.JobType, Guid> _unitOfWork;

		public CreateJobTypeHandler(IMapper mapper, 
			IJobTypeRepository jobTypeRepository, 
			IUnitOfWork<Domain.Entities.JobType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobTypeRepository = jobTypeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateJobTypeDto>> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateJobTypeValidator(_jobTypeRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Type", validatorResult);
			}

			var jobTypeToCreated = _mapper.Map<Domain.Entities.JobType>(request);
			jobTypeToCreated.Id = Guid.NewGuid();

			_jobTypeRepository.Insert(jobTypeToCreated);

			var jobTypeCreated = _mapper.Map<CreateJobTypeDto>(jobTypeToCreated);
			var data = new ApiResponse<CreateJobTypeDto>("Success", 200, jobTypeCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
