using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.ExperienceLevel.Queries.GetExperienceLevelDetail
{
	public class ExperienceLevelDetailDto
	{
		public Guid Id { get; set; }
		public string LevelName { get; set; } = null!;
	}
}
