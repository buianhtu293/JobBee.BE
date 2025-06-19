using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.SavedJob.Queries.GetSavedJobByCandidateId
{
	public class GetSavedJobByCandidateHandler : IRequestHandler<GetSavedJobByCandidateQuery, ApiResponse<PageResult<SavedJobDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IJobRepository _jobRepository;

		public GetSavedJobByCandidateHandler(IMapper mapper,
			IJobRepository jobRepository)
		{
			_mapper = mapper;
			_jobRepository = jobRepository;
		}

		public async Task<ApiResponse<PageResult<SavedJobDto>>> Handle(GetSavedJobByCandidateQuery request, CancellationToken cancellationToken)
		{
			var result = await _jobRepository.GetSavedJobByCandidateAsync(
					request.CandidateId,
					request.PageIndex,
					request.PageSize,
					cancellationToken
				);

			var jobDtos = _mapper.Map<List<SavedJobDto>>(result.Items);

			var pageResult = new PageResult<SavedJobDto>(
				jobDtos,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
				);

			return new ApiResponse<PageResult<SavedJobDto>>("Success", 200, pageResult);
		}
	}
}
