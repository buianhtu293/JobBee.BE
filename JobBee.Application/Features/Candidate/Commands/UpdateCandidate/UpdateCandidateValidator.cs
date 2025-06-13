using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Candidate.Commands.UpdateCandidate
{
	public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateCommand>
	{
		private readonly ICandidateRepository _candidateRepository;

		public UpdateCandidateValidator(ICandidateRepository candidateRepository)
		{
			_candidateRepository = candidateRepository;
		}
	}
}
