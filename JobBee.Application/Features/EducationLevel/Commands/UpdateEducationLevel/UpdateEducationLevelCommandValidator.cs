using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.EducationLevel.Commands.UpdateEducationLevel
{
	public class UpdateEducationLevelCommandValidator : AbstractValidator<UpdateEducationLevelCommand>
	{
		private readonly IEducationLevelRepository _educationLevelRepository;

		public UpdateEducationLevelCommandValidator(IEducationLevelRepository educationLevelRepository)
		{
			RuleFor(p => p.LevelName)
			   .NotEmpty().WithMessage("{PropertyName} is required")
			   .NotNull()
			   .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(p => p)
				.MustAsync(IsEducationLevelNameUnique)
				.WithMessage("Education Level already exists");

			_educationLevelRepository = educationLevelRepository;
		}

		private async Task<bool> IsEducationLevelNameUnique(UpdateEducationLevelCommand command, CancellationToken token)
		{
			var existing = await _educationLevelRepository.GetByName(command.LevelName);

			if(existing == null)
			{
				return true;
			}

			return existing.Id == command.Id;
		}
	}
}
