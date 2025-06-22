using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Queries.GetJobApplicationByJobId
{
	public class GetCandidateApplicationByJobHandler : IRequestHandler<GetCandidateApplicationByJobQuery, ApiResponse<PageResult<CandidateAppliedDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public GetCandidateApplicationByJobHandler(IMapper mapper, 
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<PageResult<CandidateAppliedDto>>> Handle(GetCandidateApplicationByJobQuery request, CancellationToken cancellationToken)
		{
			var result = await _candidateRepository.GetCandidateAppliedByJobAsync(
				request.JobId,
				request.PageIndex,
				request.PageSize,
				cancellationToken
				);

			var candidateDtos = _mapper.Map<List<CandidateAppliedDto>>(result.Items);

			var pageResult = new PageResult<CandidateAppliedDto>(
				candidateDtos,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
				);

			return new ApiResponse<PageResult<CandidateAppliedDto>>("Success", 200, pageResult);
		}
	}
}
