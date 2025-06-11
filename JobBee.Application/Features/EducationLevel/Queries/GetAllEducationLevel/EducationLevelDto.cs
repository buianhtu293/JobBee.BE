using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.EducationLevel.Queries.GetAllEducationLevel
{
	public class EducationLevelDto
	{
		public Guid Id { get; set; }
		public string LevelName { get; set; } = null!;
	}
}
