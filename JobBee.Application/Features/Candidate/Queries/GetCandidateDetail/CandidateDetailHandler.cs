using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetCandidateDetail
{
	public class CandidateDetailHandler : IRequestHandler<CandidateDetailQuery, ApiResponse<CandidateDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public CandidateDetailHandler(IMapper mapper,
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<CandidateDetailDto>> Handle(CandidateDetailQuery request, CancellationToken cancellationToken)
		{
			var candidate = _candidateRepository.GetById(request.id);

			if (candidate == null)
			{
				throw new NotFoundException(nameof(candidate), request.id);
			}

			var candidateDetail = _mapper.Map<CandidateDetailDto>(candidate);
			var data = new ApiResponse<CandidateDetailDto>("Success", 200, candidateDetail);

			return data;

		}
	}
}
