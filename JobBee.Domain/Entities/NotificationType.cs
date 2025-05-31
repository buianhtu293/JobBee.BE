using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("notification_type")]
public partial class NotificationType
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("type_name")]
	public string TypeName { get; set; } = null!;

	[Column("template")]
	public string? Template { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
