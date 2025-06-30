using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Candidate.Queries.GetCandidateDetail;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetCandidateByUserId
{
	public class GetCandidateByUserHandler : IRequestHandler<GetCandidateByUserQuery, ApiResponse<GetCandidateByUserDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;

		public GetCandidateByUserHandler(IMapper mapper, 
			ICandidateRepository candidateRepository)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
		}

		public async Task<ApiResponse<GetCandidateByUserDto>> Handle(GetCandidateByUserQuery request, CancellationToken cancellationToken)
		{
			var candidate = await _candidateRepository.GetCandidateByUserIdAsync(request.userId);

			if (candidate == null)
			{
				throw new NotFoundException(nameof(candidate), request.userId);
			}

			var candidateDetail = _mapper.Map<GetCandidateByUserDto>(candidate);
			var data = new ApiResponse<GetCandidateByUserDto>("Success", 200, candidateDetail);

			return data;
		}
	}
}
