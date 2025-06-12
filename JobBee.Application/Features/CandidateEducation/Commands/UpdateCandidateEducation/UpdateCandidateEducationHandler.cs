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

namespace JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation
{
	public class UpdateCandidateEducationHandler : IRequestHandler<UpdateCandidateEducationCommand, ApiResponse<UpdateCandidateEducationDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;
		private readonly IUnitOfWork<Domain.Entities.CandidateEducation, Guid> _unitOfWork;

		public UpdateCandidateEducationHandler(IMapper mapper, 
			ICandidateEducationRepository candidateEducationRepository, 
			IUnitOfWork<Domain.Entities.CandidateEducation, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateCandidateEducationDto>> Handle(UpdateCandidateEducationCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateCandidateEducationValidator(_candidateEducationRepository);
			var validatorResult = validator.Validate(request);

			if(validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Candidate Education", validatorResult);
			}

			var candidateEducationToUpdate = _mapper.Map<Domain.Entities.CandidateEducation>(request);
			candidateEducationToUpdate.UpdatedAt = DateTime.UtcNow;

			_candidateEducationRepository.Update(candidateEducationToUpdate);

			var candidateEducationUpdated = _mapper.Map<UpdateCandidateEducationDto>(candidateEducationToUpdate);
			var data = new ApiResponse<UpdateCandidateEducationDto>("Success", 200, candidateEducationUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
