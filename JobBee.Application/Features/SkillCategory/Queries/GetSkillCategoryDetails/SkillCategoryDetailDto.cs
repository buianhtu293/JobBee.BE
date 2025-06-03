using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.SkillCategory.Queries.GetSkillCategoryDetails
{
	public class SkillCategoryDetailDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
	}
}
