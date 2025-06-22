using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobAlert.Commands.CreateJobAlert
{
	public class CreateJobAlertDto
	{
		public Guid Id { get; set; }
		public Guid CandidateId { get; set; }
		public Guid? JobId { get; set; }
		public string AlertName { get; set; } = null!;
		public bool? IsActive { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
