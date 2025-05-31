using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("website_review")]
public partial class WebsiteReview
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("rating")]
	public int Rating { get; set; }

	[Column("review_text")]
	public string? ReviewText { get; set; }

	[Column("is_featured")]
	public bool? IsFeatured { get; set; }

	[Column("status")]
	public string? Status { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual User User { get; set; } = null!;
}
