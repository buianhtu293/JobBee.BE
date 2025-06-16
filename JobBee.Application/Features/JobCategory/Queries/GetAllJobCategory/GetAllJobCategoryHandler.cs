using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Queries.GetAllJobCategory
{
	public class GetAllJobCategoryHandler : IRequestHandler<GetAllJobCategoryQuery, ApiResponse<List<JobCategoryDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IJobCategoryRepository _jobCategoryRepository;

		public GetAllJobCategoryHandler(IMapper mapper, 
			IJobCategoryRepository jobCategoryRepository)
		{
			_mapper = mapper;
			_jobCategoryRepository = jobCategoryRepository;
		}

		public async Task<ApiResponse<List<JobCategoryDto>>> Handle(GetAllJobCategoryQuery request, CancellationToken cancellationToken)
		{
			var jobCategories = await _jobCategoryRepository.GetAllListAsync();

			var jobCategoryList = _mapper.Map<List<JobCategoryDto>>(jobCategories);
			var data = new ApiResponse<List<JobCategoryDto>>("Success", 200, jobCategoryList);

			return data;
		}
	}
}
