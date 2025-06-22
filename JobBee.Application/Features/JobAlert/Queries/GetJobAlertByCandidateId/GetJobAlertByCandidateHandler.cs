using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.SavedJob.Queries.GetSavedJobByCandidateId;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.JobAlert.Queries.GetJobAlertByCandidateId
{
	public class GetJobAlertByCandidateHandler : IRequestHandler<GetJobAlertByCandidateQuery, ApiResponse<PageResult<JobAlertDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IJobRepository _jobRepository;

		public GetJobAlertByCandidateHandler(IMapper mapper, 
			IJobRepository jobRepository)
		{
			_mapper = mapper;
			_jobRepository = jobRepository;
		}

		public async Task<ApiResponse<PageResult<JobAlertDto>>> Handle(GetJobAlertByCandidateQuery request, CancellationToken cancellationToken)
		{
			var result = await _jobRepository.GetJobAlertByCandidateAsync(
					request.CandidateId,
					request.PageIndex,
					request.PageSize,
					cancellationToken
				);

			var jobDtos = _mapper.Map<List<JobAlertDto>>(result.Items);

			var pageResult = new PageResult<JobAlertDto>(
				jobDtos,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
				);

			return new ApiResponse<PageResult<JobAlertDto>>("Success", 200, pageResult);
		}
	}
}
