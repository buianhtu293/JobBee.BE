using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Skill.Commands.AddSkill
{
	public class CreateSkillDto
	{
		public Guid Id { get; set; }
		public string SkillName { get; set; } = null!;
		public Guid? CategoryId { get; set; }
	}
}
