using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Commands.CreateJobAppliaction
{
	public class CreateJobApplicationCommand : IRequest<ApiResponse<CreateJobApplicationDto>>
	{
		public Guid JobId { get; set; }
		public Guid CandidateId { get; set; }
		public Guid? ResumeId { get; set; }
		public string? CoverLetter { get; set; }
		public string Status { get; set; } = null!;  // e.g. "Applied", "Reviewed", "Rejected", etc.
		public string? EmployerNotes { get; set; }
	}
}
