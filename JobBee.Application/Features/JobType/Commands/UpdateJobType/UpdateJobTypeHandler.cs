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

namespace JobBee.Application.Features.JobType.Commands.UpdateJobType
{
	public class UpdateJobTypeHandler : IRequestHandler<UpdateJobTypeCommand, ApiResponse<UpdateJobTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobTypeRepository _jobTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.JobType, Guid> _unitOfWork;

		public UpdateJobTypeHandler(IMapper mapper,
			IJobTypeRepository jobTypeRepository,
			IUnitOfWork<Domain.Entities.JobType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobTypeRepository = jobTypeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateJobTypeDto>> Handle(UpdateJobTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateJobTypeValidator(_jobTypeRepository);
			var validatorResult  = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Type", validatorResult);
			}

			var jobTypeToUpdate = _mapper.Map<Domain.Entities.JobType>(request);

			_jobTypeRepository.Update(jobTypeToUpdate);

			var jobTypeUpdated = _mapper.Map<UpdateJobTypeDto>(jobTypeToUpdate);
			var data = new ApiResponse<UpdateJobTypeDto>("Success", 200, jobTypeUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
