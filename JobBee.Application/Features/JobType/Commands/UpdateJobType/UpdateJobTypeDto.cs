using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobType.Commands.UpdateJobType
{
	public class UpdateJobTypeDto
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
	}
}
