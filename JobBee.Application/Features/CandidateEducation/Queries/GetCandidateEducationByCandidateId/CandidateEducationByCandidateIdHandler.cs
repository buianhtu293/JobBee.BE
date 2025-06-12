using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationByCandidateId
{
	public class CandidateEducationByCandidateIdHandler : IRequestHandler<CandidateEducationByCandidateIdQuery, ApiResponse<List<CandidateEducationByCandidateIdDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;
		private readonly IUnitOfWork<Domain.Entities.CandidateEducation, Guid> _unitOfWork;

		public CandidateEducationByCandidateIdHandler(IMapper mapper, 
			ICandidateEducationRepository candidateEducationRepository, 
			IUnitOfWork<Domain.Entities.CandidateEducation, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<List<CandidateEducationByCandidateIdDto>>> Handle(CandidateEducationByCandidateIdQuery request, CancellationToken cancellationToken)
		{
			var candidateEducations = await _candidateEducationRepository.GetCandidateEducationByCandidateId(request.id);

			var candidateEducationList = _mapper.Map<List<CandidateEducationByCandidateIdDto>>(candidateEducations);
			var data = new ApiResponse<List<CandidateEducationByCandidateIdDto>>("Success", 200, candidateEducationList);

			return data;
		}
	}
}
