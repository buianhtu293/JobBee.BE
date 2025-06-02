using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_portfolio")]
public partial class CandidatePortfolio
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("title")]
	public string Title { get; set; } = null!;

	[Column("description")]
	public string? Description { get; set; }

	[Column("project_url")]
	public string? ProjectUrl { get; set; }

	[Column("image_url")]
	public string? ImageUrl { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;
}
