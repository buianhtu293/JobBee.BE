using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate
{
	public class CreateSavedCandidateValidator : AbstractValidator<CreateSavedCandidateCommand>
	{
		private readonly ISavedCandidateRepository _savedCandidateRepository;

		public CreateSavedCandidateValidator(ISavedCandidateRepository savedCandidateRepository)
		{
			_savedCandidateRepository = savedCandidateRepository;
		}
	}
}
