using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("reported_content")]
public partial class ReportedContent
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("reporter_user_id")]
	public Guid ReporterUserId { get; set; }

	[Column("content_type")]
	public string ContentType { get; set; } = null!;

	[Column("content_id")]
	public int ContentId { get; set; }

	[Column("reason")]
	public string Reason { get; set; } = null!;

	[Column("details")]
	public string? Details { get; set; }

	[Column("status")]
	public string? Status { get; set; }

	[Column("admin_notes")]
	public string? AdminNotes { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual User ReporterUser { get; set; } = null!;
}
