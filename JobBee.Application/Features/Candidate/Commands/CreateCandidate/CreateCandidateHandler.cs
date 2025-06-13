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

namespace JobBee.Application.Features.Candidate.Commands.CreateCandidate
{
	public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, ApiResponse<CreateCandidateDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;
		private readonly IUnitOfWork<Domain.Entities.Candidate, Guid> _unitOfWork;

		public CreateCandidateHandler(IMapper mapper, 
			ICandidateRepository candidateRepository, 
			IUnitOfWork<Domain.Entities.Candidate, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateCandidateDto>> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateCandidateValidator(_candidateRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Candidate", validatorResult);
			}

			var candidateToCreate = _mapper.Map<Domain.Entities.Candidate>(request);

			candidateToCreate.Id = Guid.NewGuid();
			candidateToCreate.CreatedAt = DateTime.Now;
			candidateToCreate.UpdatedAt = DateTime.Now;

			_candidateRepository.Insert(candidateToCreate);

			var candidateCreated = _mapper.Map<CreateCandidateDto>(candidateToCreate);
			var data = new ApiResponse<CreateCandidateDto>("Success", 200, candidateCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
