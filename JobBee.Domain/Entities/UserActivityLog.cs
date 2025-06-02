using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("user_activity_log")]
public partial class UserActivityLog
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid? UserId { get; set; }

	[Column("activity_type")]
	public string ActivityType { get; set; } = null!;

	[Column("ip_address")]
	public string? IpAddress { get; set; }

	[Column("user_agent")]
	public string? UserAgent { get; set; }

	[Column("details")]
	public string? Details { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual User? User { get; set; }
}
