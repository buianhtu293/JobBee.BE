using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("email_setting")]
public partial class EmailSetting
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("job_alerts")]
	public bool? JobAlerts { get; set; }

	[Column("application_updates")]
	public bool? ApplicationUpdates { get; set; }

	[Column("profile_views")]
	public bool? ProfileViews { get; set; }

	[Column("job_recommendations")]
	public bool? JobRecommendations { get; set; }

	[Column("marketing_emails")]
	public bool? MarketingEmails { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual User User { get; set; } = null!;
}
