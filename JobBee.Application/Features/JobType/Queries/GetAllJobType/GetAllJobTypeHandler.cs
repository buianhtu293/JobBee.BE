using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobType.Queries.GetAllJobType
{
	public class GetAllJobTypeHandler : IRequestHandler<GetAllJobTypeQuery, ApiResponse<List<JobTypeDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IJobTypeRepository _jobTypeRepository;

		public GetAllJobTypeHandler(IMapper mapper, 
			IJobTypeRepository jobTypeRepository)
		{
			_mapper = mapper;
			_jobTypeRepository = jobTypeRepository;
		}

		public async Task<ApiResponse<List<JobTypeDto>>> Handle(GetAllJobTypeQuery request, CancellationToken cancellationToken)
		{
			var jobTypes = await _jobTypeRepository.GetAllListAsync();

			var jobTypeList = _mapper.Map<List<JobTypeDto>>(jobTypes);
			var data = new ApiResponse<List<JobTypeDto>>("Success", 200, jobTypeList);

			return data;
		}
	}
}
