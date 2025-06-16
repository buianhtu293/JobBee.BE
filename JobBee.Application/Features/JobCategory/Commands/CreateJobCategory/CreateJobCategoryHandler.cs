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

namespace JobBee.Application.Features.JobCategory.Commands.CreateJobCategory
{
	public class CreateJobCategoryHandler : IRequestHandler<CreateJobCategoryCommand, ApiResponse<CreateJobCategoryDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobCategoryRepository _jobCategoryRepository;
		private readonly IUnitOfWork<Domain.Entities.JobCategory, Guid> _unitOfWork;

		public CreateJobCategoryHandler(IMapper mapper, 
			IJobCategoryRepository jobCategoryRepository, 
			IUnitOfWork<Domain.Entities.JobCategory, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobCategoryRepository = jobCategoryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateJobCategoryDto>> Handle(CreateJobCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateJobCategoryValidator(_jobCategoryRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Job Category", validatorResult);
			}

			var jobCategoryToCreate = _mapper.Map<Domain.Entities.JobCategory>(request);
			jobCategoryToCreate.Id = Guid.NewGuid();
			jobCategoryToCreate.CreatedAt = DateTime.Now;

			_jobCategoryRepository.Insert(jobCategoryToCreate);

			var jobCategoryCreated = _mapper.Map<CreateJobCategoryDto>(jobCategoryToCreate);
			var data = new ApiResponse<CreateJobCategoryDto>("Success", 200, jobCategoryCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
