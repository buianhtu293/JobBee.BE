using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation
{
	public class CreateCandidateEducationValidator : AbstractValidator<CreateCandidateEducationCommand>
	{
		private readonly ICandidateEducationRepository _candidateEducationRepository;

		public CreateCandidateEducationValidator(ICandidateEducationRepository candidateEducationRepository)
		{
			_candidateEducationRepository = candidateEducationRepository;
		}
	}
}
