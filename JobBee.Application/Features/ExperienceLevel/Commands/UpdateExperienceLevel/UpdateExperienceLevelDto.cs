using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel
{
	public class UpdateExperienceLevelDto
	{
		public Guid Id { get; set; }
		public string LevelName { get; set; } = null!;
	}
}
