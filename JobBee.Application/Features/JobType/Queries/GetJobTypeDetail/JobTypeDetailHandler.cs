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

namespace JobBee.Application.Features.JobType.Queries.GetJobTypeDetail
{
	public class JobTypeDetailHandler : IRequestHandler<JobTypeDetailQuery, ApiResponse<JobTypeDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IJobTypeRepository _jobTypeRepository;

		public JobTypeDetailHandler(IMapper mapper,
			IJobTypeRepository jobTypeRepository)
		{
			_mapper = mapper;
			_jobTypeRepository = jobTypeRepository;
		}

		public async Task<ApiResponse<JobTypeDetailDto>> Handle(JobTypeDetailQuery request, CancellationToken cancellationToken)
		{
			var jobType = _jobTypeRepository.GetById(request.id);

			if (jobType == null)
			{
				throw new NotFoundException(nameof(jobType), request.id);
			}

			var jobTypeDetail = _mapper.Map<JobTypeDetailDto>(jobType);
			var data = new ApiResponse<JobTypeDetailDto>("Success", 200, jobTypeDetail);

			return data;

		}
	}
}
