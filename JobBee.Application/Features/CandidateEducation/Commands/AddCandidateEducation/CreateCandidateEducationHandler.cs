using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation
{
	public class CreateCandidateEducationHandler : IRequestHandler<CreateCandidateEducationCommand, ApiResponse<CreateCandidateEducationDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;
		private readonly IUnitOfWork<Domain.Entities.CandidateEducation, Guid> _unitOfWork;

		public CreateCandidateEducationHandler(IMapper mapper, 
			ICandidateEducationRepository candidateEducationRepository, 
			IUnitOfWork<Domain.Entities.CandidateEducation, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateCandidateEducationDto>> Handle(CreateCandidateEducationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateCandidateEducationValidator(_candidateEducationRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if(validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Candidate Education", validatorResult);
			}

			var candidateEducationToCreate = _mapper.Map<Domain.Entities.CandidateEducation>(request);
			//var candidateEducationToCreate = new Domain.Entities.CandidateEducation();

			candidateEducationToCreate.Id = Guid.NewGuid();
			//candidateEducationToCreate.CandidateId = request.CandidateId;
			//candidateEducationToCreate.InstitutionName = request.InstitutionName;
			//candidateEducationToCreate.EducationLevelId = request.EducationLevelId;
			//candidateEducationToCreate.FieldOfStudy = request.FieldOfStudy;
			//DateTime dateTime = request.StartDate.Value;
			//candidateEducationToCreate.StartDate = DateOnly.FromDateTime(dateTime);
			//dateTime = request.EndDate.Value;
			//candidateEducationToCreate.EndDate = DateOnly.FromDateTime(dateTime);
			//candidateEducationToCreate.IsCurrent = request.IsCurrent;
			//candidateEducationToCreate.Description = request.Description;
			candidateEducationToCreate.CreatedAt = DateTime.UtcNow;
			candidateEducationToCreate.UpdatedAt = DateTime.UtcNow;

			_candidateEducationRepository.Insert(candidateEducationToCreate);

			var candidateEducationCreated = _mapper.Map<CreateCandidateEducationDto>(candidateEducationToCreate);
			var data = new ApiResponse<CreateCandidateEducationDto>("Success", 201, candidateEducationCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
