using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResume;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResumeByCandidateId
{
	internal class GetCandidateResumeByCandidateIdHandler : IRequestHandler<GetCandidateResumeByCandidateIdQuery, ApiResponse<List<CandidateResumeDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateResumeRepository _candidateResumeRepository;

		public GetCandidateResumeByCandidateIdHandler(IMapper mapper, 
			ICandidateResumeRepository candidateResumeRepository)
		{
			_mapper = mapper;
			_candidateResumeRepository = candidateResumeRepository;
		}

		public async Task<ApiResponse<List<CandidateResumeDto>>> Handle(GetCandidateResumeByCandidateIdQuery request, CancellationToken cancellationToken)
		{
			var candidateResumes = await _candidateResumeRepository.GetCandidateResumeByCandidateId(request.id);

			if(candidateResumes == null)
			{
				throw new NotFoundException(nameof(candidateResumes), request.id);
			}

			var candidateResumeList = _mapper.Map<List<CandidateResumeDto>>(candidateResumes);
			var data = new ApiResponse<List<CandidateResumeDto>>("Success", 200, candidateResumeList);

			return data;
		}
	}
}
