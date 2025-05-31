using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("notification")]
public partial class Notification
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("notification_type_id")]
	public Guid NotificationTypeId { get; set; }

	[Column("title")]
	public string Title { get; set; } = null!;

	[Column("message")]
	public string Message { get; set; } = null!;

	[Column("is_read")]
	public bool? IsRead { get; set; }

	[Column("related_entity_type")]
	public string? RelatedEntityType { get; set; }

	[Column("related_entity_id")]
	public int? RelatedEntityId { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual NotificationType NotificationType { get; set; } = null!;

	public virtual User User { get; set; } = null!;
}
