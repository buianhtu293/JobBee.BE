using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction
{
	public class CreateJobApplicationDto
	{
		public Guid Id { get; set; }
		public Guid JobId { get; set; }
		public Guid CandidateId { get; set; }
		public Guid? ResumeId { get; set; }
		public string? CoverLetter { get; set; }
		public string Status { get; set; } = null!;  // e.g. "Applied", "Reviewed", "Rejected", etc.
		public string? EmployerNotes { get; set; }
		public DateTime? AppliedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
