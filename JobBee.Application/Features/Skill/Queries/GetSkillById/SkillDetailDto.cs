using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Skill.Queries.GetSkillById
{
	public class SkillDetailDto
	{
		public Guid Id { get; set; }
		public string SkillName { get; set; } = null!;
		public Guid? CategoryId { get; set; }
	}
}
