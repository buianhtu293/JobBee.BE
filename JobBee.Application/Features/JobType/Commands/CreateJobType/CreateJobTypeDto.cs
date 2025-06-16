using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobType.Commands.CreateJobType
{
	public class CreateJobTypeDto
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
	}
}
