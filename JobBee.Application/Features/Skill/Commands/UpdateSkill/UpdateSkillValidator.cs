using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Skill.Commands.UpdateSkill
{
	public class UpdateSkillValidator : AbstractValidator<UpdateSkillCommand>
	{
		private readonly ISkillRepository _skillRepository;

		public UpdateSkillValidator(ISkillRepository skillRepository)
		{
			_skillRepository = skillRepository;
		}
	}
}
