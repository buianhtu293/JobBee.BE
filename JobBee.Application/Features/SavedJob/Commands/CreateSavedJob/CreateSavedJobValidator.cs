using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.SavedJob.Commands.CreateSavedJob
{
	public class CreateSavedJobValidator : AbstractValidator<CreateSavedJobCommand>
	{
		private readonly ISavedJobRepository _savedJobRepository;

		public CreateSavedJobValidator(ISavedJobRepository savedJobRepository)
		{
			_savedJobRepository = savedJobRepository;
		}
	}
}
