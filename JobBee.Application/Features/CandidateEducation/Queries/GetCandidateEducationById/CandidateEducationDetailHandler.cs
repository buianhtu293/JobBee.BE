using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationById
{
	public class CandidateEducationDetailHandler : IRequestHandler<CandidateEducationDetailQuery, ApiResponse<CandidateEducationDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;

		public CandidateEducationDetailHandler(IMapper mapper, 
			ICandidateEducationRepository candidateEducationRepository)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
		}

		public async Task<ApiResponse<CandidateEducationDetailDto>> Handle(CandidateEducationDetailQuery request, CancellationToken cancellationToken)
		{
			var candidateEducation = _candidateEducationRepository.GetByIdIncluding(
					request.id,
					e => e.EducationLevel
				);

			if (candidateEducation == null)
			{
				throw new NotFoundException(nameof(candidateEducation), request.id);
			}

			var candidateEducationDetail = _mapper.Map<CandidateEducationDetailDto>(candidateEducation);
			var data = new ApiResponse<CandidateEducationDetailDto>("Success", 200, candidateEducationDetail);

			return data;

		}
	}
}
