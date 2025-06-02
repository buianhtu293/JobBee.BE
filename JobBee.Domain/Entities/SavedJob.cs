using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("saved_job")]
public partial class SavedJob
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("job_id")]
	public Guid JobId { get; set; }

	[Column("saved_at")]
	public DateTime? SavedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Job Job { get; set; } = null!;
}
