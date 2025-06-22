using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation
{
	public class CandidateEducationHandler : IRequestHandler<CandidateEducationQuery, ApiResponse<List<CandidateEducationDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;
		private readonly IUnitOfWork<Domain.Entities.CandidateEducation, Guid> _unitOfWork;

		public CandidateEducationHandler(IMapper mapper,
			ICandidateEducationRepository candidateEducationRepository,
			IUnitOfWork<Domain.Entities.CandidateEducation, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<List<CandidateEducationDto>>> Handle(CandidateEducationQuery request, CancellationToken cancellationToken)
		{
			var candidateEducations = _candidateEducationRepository.GetAllIncluding(
					e => e.EducationLevel
				).ToList();

			var candidateEducationList = _mapper.Map<List<CandidateEducationDto>>(candidateEducations);
			var data = new ApiResponse<List<CandidateEducationDto>>("Success", 200, candidateEducationList);

			return data;

		}
	}
}
