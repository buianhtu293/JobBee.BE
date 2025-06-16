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

namespace JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory
{
	public class UpdateJobCategoryHandler : IRequestHandler<UpdateJobCategoryCommand, ApiResponse<UpdateJobCategoryDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobCategoryRepository _jobCategoryRepository;
		private readonly IUnitOfWork<Domain.Entities.JobCategory, Guid> _unitOfWork;

		public UpdateJobCategoryHandler(IMapper mapper,
			IJobCategoryRepository jobCategoryRepository,
			IUnitOfWork<Domain.Entities.JobCategory, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobCategoryRepository = jobCategoryRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<UpdateJobCategoryDto>> Handle(UpdateJobCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateJobCategoryValidator(_jobCategoryRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Category", validatorResult);
			}

			var jobCategoryExisted = _jobCategoryRepository.GetById(request.Id);

			var jobCategoryToUpdate = _mapper.Map<Domain.Entities.JobCategory>(request);
			jobCategoryToUpdate.CreatedAt = jobCategoryExisted.CreatedAt;

			_jobCategoryRepository.Update(jobCategoryToUpdate);

			var jobCategoryCreated = _mapper.Map<UpdateJobCategoryDto>(jobCategoryToUpdate);
			var data = new ApiResponse<UpdateJobCategoryDto>("Success", 200, jobCategoryCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
