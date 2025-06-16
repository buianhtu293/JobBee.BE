using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel
{
	public class UpdateExperienceLevelValidator : AbstractValidator<UpdateExperienceLevelCommand>
	{
		private readonly IExperienceLevelRepository _experienceLevelRepository;

		public UpdateExperienceLevelValidator(IExperienceLevelRepository experienceLevelRepository)
		{
			_experienceLevelRepository = experienceLevelRepository;
		}
	}
}
