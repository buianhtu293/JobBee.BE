using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("email_log")]
public partial class EmailLog
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("recipient_email")]
	public string RecipientEmail { get; set; } = null!;

	[Column("subject")]
	public string Subject { get; set; } = null!;

	[Column("template_id")]
	public Guid? TemplateId { get; set; }

	[Column("sent_at")]
	public DateTime? SentAt { get; set; }

	[Column("status")]
	public string Status { get; set; } = null!;

	[Column("error_message")]
	public string? ErrorMessage { get; set; }

	public virtual EmailTemplate? Template { get; set; }
}
