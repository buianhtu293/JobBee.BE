using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_application")]
public partial class JobApplication
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("job_id")]
	public Guid JobId { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("resume_id")]
	public Guid? ResumeId { get; set; }

	[Column("cover_letter")]
	public string? CoverLetter { get; set; }

	[Column("status")]
	public string Status { get; set; } = null!;  // e.g. "Applied", "Reviewed", "Rejected", etc.

	[Column("employer_notes")]
	public string? EmployerNotes { get; set; }

	[Column("applied_at")]
	public DateTime? AppliedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Job Job { get; set; } = null!;

	public virtual CandidateResume? Resume { get; set; }
}
