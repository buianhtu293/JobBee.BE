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

namespace JobBee.Application.Features.SavedCandidate.Queries.GetSavedCandidateByEmployer
{
	public class GetsavedCandidateByEmployerHandler : IRequestHandler<GetSavedCandidateByEmployerQuery, ApiResponse<PageResult<SavedCandidateDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public GetsavedCandidateByEmployerHandler(IMapper mapper, 
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<PageResult<SavedCandidateDto>>> Handle(GetSavedCandidateByEmployerQuery request, CancellationToken cancellationToken)
		{
			var result = await _candidateRepository.GetSavedCandiddateByEmployerAsync(
					request.EmployerId,
					request.PageIndex,
					request.PageSize,
					cancellationToken
				);

			var candidateDtos = _mapper.Map<List<SavedCandidateDto>>(result.Items);

			var pageResult = new PageResult<SavedCandidateDto>(
					candidateDtos,
					result.TotalItems,
					result.PageIndex,
					result.PageSize
				);

			return new ApiResponse<PageResult<SavedCandidateDto>>("Success", 200, pageResult);
		}
	}
}
