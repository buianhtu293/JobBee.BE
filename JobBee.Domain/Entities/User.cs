using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("user")]
public partial class User
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_name")]
	public string? UserName { get; set; }

	[Column("normalized_user_name")]
	public string? NormalizedUserName { get; set; }

	[Column("email")]
	public string? Email { get; set; }

	[Column("normalized_email")]
	public string? NormalizedEmail { get; set; }

	[Column("email_confirmed")]
	public bool EmailConfirmed { get; set; }

	[Column("password_hash")]
	public string? PasswordHash { get; set; }

	[Column("security_stamp")]
	public string? SecurityStamp { get; set; }

	[Column("concurrency_stamp")]
	public string? ConcurrencyStamp { get; set; }

	[Column("phone_number")]
	public string? PhoneNumber { get; set; }

	[Column("phone_number_confirmed")]
	public bool PhoneNumberConfirmed { get; set; }

	[Column("two_factor_enabled")]
	public bool TwoFactorEnabled { get; set; }

	[Column("lockout_end")]
	public DateTime? LockoutEnd { get; set; }

	[Column("lockout_enabled")]
	public bool LockoutEnabled { get; set; }

	[Column("access_failed_count")]
	public int AccessFailedCount { get; set; }

	public virtual Candidate? Candidate { get; set; }

	public virtual ICollection<EmailSetting> EmailSettings { get; set; } = new List<EmailSetting>();

	public virtual Employer? Employer { get; set; }

	public virtual ICollection<JobSearchLog> JobSearchLogs { get; set; } = new List<JobSearchLog>();

	public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

	public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

	public virtual ICollection<ReportedContent> ReportedContents { get; set; } = new List<ReportedContent>();

	public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

	public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();

	public virtual ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();

	public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

	public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

	public virtual ICollection<WebsiteReview> WebsiteReviews { get; set; } = new List<WebsiteReview>();

	public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
