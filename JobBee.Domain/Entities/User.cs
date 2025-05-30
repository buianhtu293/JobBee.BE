using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

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
