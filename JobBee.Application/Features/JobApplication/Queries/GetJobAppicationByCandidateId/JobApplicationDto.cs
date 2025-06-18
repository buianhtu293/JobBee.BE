using System.ComponentModel.DataAnnotations.Schema;
using JobBee.Application.Features.Candidate.Queries.GetAllCandidate;
using JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResume;
using JobBee.Application.Features.Job.Queries.GetAllJobs;

namespace JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId
{
	public class JobApplicationDto
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
