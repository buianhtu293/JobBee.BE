using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation
{
	public class UpdateCandidateEducationValidator : AbstractValidator<UpdateCandidateEducationCommand>
	{
		private readonly ICandidateEducationRepository _candidateEducationRepository;

		public UpdateCandidateEducationValidator(ICandidateEducationRepository candidateEducationRepository)
		{
			_candidateEducationRepository = candidateEducationRepository;
		}
	}
}
