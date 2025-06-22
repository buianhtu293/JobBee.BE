using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.CandidateResume.Commands.CreateCandidateResume
{
	public class CreateCandidateResumeValidator : AbstractValidator<CreateCandidateResumeCommand>
	{
		private readonly ICandidateResumeRepository _candidateResumeRepository;

		public CreateCandidateResumeValidator(ICandidateResumeRepository candidateResumeRepository)
		{
			_candidateResumeRepository = candidateResumeRepository;
		}
	}
}
