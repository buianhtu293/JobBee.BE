using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Skill.Commands.AddSkill
{
	public class CreateSkillValidator : AbstractValidator<CreateSkillCommand>
	{
		private readonly ISkillRepository _skillRepository;

		public CreateSkillValidator(ISkillRepository skillRepository)
		{
			_skillRepository = skillRepository;
		}
	}
}
