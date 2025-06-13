using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetAllCandidate
{
	public class CandidateHandler : IRequestHandler<CandidateQuery, ApiResponse<List<CandidateDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public CandidateHandler(IMapper mapper,
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<List<CandidateDto>>> Handle(CandidateQuery request, CancellationToken cancellationToken)
		{
			var candidates = await _candidateRepository.GetAllListAsync();

			var candidateLists = _mapper.Map<List<CandidateDto>>(candidates);
			var data = new ApiResponse<List<CandidateDto>>("Success", 200, candidateLists);

			return data;
		}
	}
}
