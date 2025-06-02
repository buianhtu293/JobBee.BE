using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("subscription_plan")]
public partial class SubscriptionPlan
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("plan_name")]
	public string PlanName { get; set; } = null!;

	[Column("plan_type")]
	public string PlanType { get; set; } = null!;

	[Column("price")]
	public decimal Price { get; set; }

	[Column("currency")]
	public string Currency { get; set; } = null!;

	[Column("billing_cycle")]
	public string BillingCycle { get; set; } = null!;

	[Column("description")]
	public string? Description { get; set; }

	[Column("job_posting_limit")]
	public int? JobPostingLimit { get; set; }

	[Column("featured_job_limit")]
	public int? FeaturedJobLimit { get; set; }

	[Column("candidate_search_limit")]
	public int? CandidateSearchLimit { get; set; }

	[Column("resume_access_limit")]
	public int? ResumeAccessLimit { get; set; }

	[Column("profile_visibility")]
	public bool? ProfileVisibility { get; set; }

	[Column("priority_listing")]
	public bool? PriorityListing { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
