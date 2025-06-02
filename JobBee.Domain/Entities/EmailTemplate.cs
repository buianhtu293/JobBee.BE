using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("email_template")]
public partial class EmailTemplate
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("template_name")]
	public string TemplateName { get; set; } = null!;

	[Column("subject")]
	public string Subject { get; set; } = null!;

	[Column("body")]
	public string Body { get; set; } = null!;

	[Column("variables")]
	public string? Variables { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();
}
