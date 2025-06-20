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

namespace JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate
{
	public class CreateSavedCandidateHandler : IRequestHandler<CreateSavedCandidateCommand, ApiResponse<CreateSavedCandidateDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISavedCandidateRepository _savedCandidateRepository;
		private IUnitOfWork<Domain.Entities.SavedCandidate, Guid> _unitOfWork;

		public CreateSavedCandidateHandler(IMapper mapper, 
			ISavedCandidateRepository savedCandidateRepository, 
			IUnitOfWork<Domain.Entities.SavedCandidate, Guid> unitOfWork)
		{
			_mapper = mapper;
			_savedCandidateRepository = savedCandidateRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateSavedCandidateDto>> Handle(CreateSavedCandidateCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateSavedCandidateValidator(_savedCandidateRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Saved Candidate", validatorResult);
			}

			var savedCandidateToCreate = _mapper.Map<Domain.Entities.SavedCandidate>(request);
			savedCandidateToCreate.Id = Guid.NewGuid();
			savedCandidateToCreate.SavedAt = DateTime.Now;

			_savedCandidateRepository.Insert(savedCandidateToCreate);

			var savedCandidateCreated = _mapper.Map<CreateSavedCandidateDto>(savedCandidateToCreate);
			var data = new ApiResponse<CreateSavedCandidateDto>("Success", 200, savedCandidateCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
