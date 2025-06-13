using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Candidate.Commands.CreateCandidate
{
	public class CreateCandidateValidator : AbstractValidator<CreateCandidateCommand>
	{
		private readonly ICandidateRepository _candidateRepository;

		public CreateCandidateValidator(ICandidateRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
		}
	}
}
