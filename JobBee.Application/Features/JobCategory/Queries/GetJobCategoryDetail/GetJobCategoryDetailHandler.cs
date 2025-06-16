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

namespace JobBee.Application.Features.JobCategory.Queries.GetJobCategoryDetail
{
	public class GetJobCategoryDetailHandler : IRequestHandler<GetJobCategoryDetailQuery, ApiResponse<JobCategoryDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobCategoryRepository _jobCategoryRepository;

		public GetJobCategoryDetailHandler(IMapper mapper,
			IJobCategoryRepository jobCategoryRepository)
		{
			_mapper = mapper;
			_jobCategoryRepository = jobCategoryRepository;
		}
		public async Task<ApiResponse<JobCategoryDetailDto>> Handle(GetJobCategoryDetailQuery request, CancellationToken cancellationToken)
		{
			var jobCategory = _jobCategoryRepository.GetById(request.id);

			if (jobCategory == null)
			{
				throw new NotFoundException(nameof(jobCategory), request.id);
			}

			var jobCategoryDetail = _mapper.Map<JobCategoryDetailDto>(jobCategory);
			var data = new ApiResponse<JobCategoryDetailDto>("Success", 200, jobCategoryDetail);

			return data;
		}
	}
}
