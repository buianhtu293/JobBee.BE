using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_alert")]
public partial class JobAlert
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("job_id")]
	public Guid? JobId { get; set; }

	[Column("alert_name")]
	public string AlertName { get; set; } = null!;

	[Column("is_active")]
	public bool? IsActive { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Job? Job { get; set; }
}
