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

namespace JobBee.Application.Features.CandidateResume.Queries.GetCandidateResumeDetail
{
	public class GetCandidateResumeDetailHandler : IRequestHandler<GetCandidateResumeDetailQuery, ApiResponse<CandidateResumeDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateResumeRepository _candidateResumeRepository;

		public GetCandidateResumeDetailHandler(IMapper mapper,
			ICandidateResumeRepository candidateResumeRepository)
		{
			_mapper = mapper;
			_candidateResumeRepository = candidateResumeRepository;
		}
		public async Task<ApiResponse<CandidateResumeDetailDto>> Handle(GetCandidateResumeDetailQuery request, CancellationToken cancellationToken)
		{
			var candidateResume = _candidateResumeRepository.GetById(request.id);

			if (candidateResume == null)
			{
				throw new NotFoundException(nameof(candidateResume), request.id);
			}

			var candidateResumeDetail = _mapper.Map<CandidateResumeDetailDto>(candidateResume);
			var data = new ApiResponse<CandidateResumeDetailDto>("Success", 200, candidateResumeDetail);

			return data;
		}
	}
}
