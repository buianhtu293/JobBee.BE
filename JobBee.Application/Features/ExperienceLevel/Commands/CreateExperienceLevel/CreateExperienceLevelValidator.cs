using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.ExperienceLevel.Commands.CreateExperienceLevel
{
	public class CreateExperienceLevelValidator : AbstractValidator<CreateExperienceLevelCommand>
	{
		private readonly IExperienceLevelRepository _experienceLevelRepository;

		public CreateExperienceLevelValidator(IExperienceLevelRepository experienceLevelRepository)
		{
			_experienceLevelRepository = experienceLevelRepository;
		}
	}
}
