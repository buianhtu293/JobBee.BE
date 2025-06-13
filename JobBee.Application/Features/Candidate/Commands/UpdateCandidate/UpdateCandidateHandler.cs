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

namespace JobBee.Application.Features.Candidate.Commands.UpdateCandidate
{
	public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, ApiResponse<UpdateCandidateDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;
		private readonly IUnitOfWork<Domain.Entities.Candidate, Guid> _unitOfWork;

		public UpdateCandidateHandler(IMapper mapper,
			ICandidateRepository candidateRepository,
			IUnitOfWork<Domain.Entities.Candidate, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateCandidateDto>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateCandidateValidator(_candidateRepository);
			var validatorResult = validator.Validate(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Candidate", validatorResult);
			}

			var candidateExisted = _candidateRepository.GetById(request.Id);

			var candidateToUpdate = _mapper.Map<Domain.Entities.Candidate>(request);
			candidateToUpdate.UserId = candidateExisted.UserId;
			candidateToUpdate.CreatedAt = candidateExisted.CreatedAt;
			candidateToUpdate.UpdatedAt = DateTime.Now;

			_candidateRepository.Update(candidateToUpdate);

			var candidateUpdated = _mapper.Map<UpdateCandidateDto>(candidateToUpdate);
			var data = new ApiResponse<UpdateCandidateDto>("Success", 200, candidateUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
