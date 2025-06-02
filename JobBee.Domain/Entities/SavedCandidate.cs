using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("saved_candidate")]
public partial class SavedCandidate
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("saved_at")]
	public DateTime? SavedAt { get; set; }

	[Column("notes")]
	public string? Notes { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Employer Employer { get; set; } = null!;
}
