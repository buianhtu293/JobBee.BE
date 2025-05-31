using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("employer_review")]
public partial class EmployerReview
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("rating")]
	public int Rating { get; set; }

	[Column("title")]
	public string? Title { get; set; }

	[Column("review_text")]
	public string? ReviewText { get; set; }

	[Column("pros")]
	public string? Pros { get; set; }

	[Column("cons")]
	public string? Cons { get; set; }

	[Column("is_anonymous")]
	public bool? IsAnonymous { get; set; }

	[Column("status")]
	public string? Status { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Employer Employer { get; set; } = null!;
}
