using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId
{
	public class GetJobApplicationByCandidateHandler : IRequestHandler<GetJobApplicationByCandidateIdQuery, ApiResponse<PageResult<JobAppliedDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IJobRepository _jobRepository;

		public GetJobApplicationByCandidateHandler(IMapper mapper,
			IJobApplicationRepository jobApplicationRepository,
			IJobRepository jobRepository)
		{
			_mapper = mapper;
			_jobApplicationRepository = jobApplicationRepository;
			_jobRepository = jobRepository;
		}

		public async Task<ApiResponse<PageResult<JobAppliedDto>>> Handle(GetJobApplicationByCandidateIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _jobRepository.GetJobsAppliedByCandidateAsync(
				request.CandidateId,
				request.PageIndex,
				request.PageSize,
				cancellationToken
			);

			var jobDtos = _mapper.Map<List<JobAppliedDto>>(result.Items);

			var pageResult = new PageResult<JobAppliedDto>(
				jobDtos,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
				);

			return new ApiResponse<PageResult<JobAppliedDto>>("Success", 200, pageResult);
		}
	}
}
