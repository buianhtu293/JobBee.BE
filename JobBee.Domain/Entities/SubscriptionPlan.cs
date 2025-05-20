using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class SubscriptionPlan
{
    public Guid Id { get; set; }

    public string PlanName { get; set; } = null!;

    public string PlanType { get; set; } = null!;

    public decimal Price { get; set; }

    public string Currency { get; set; } = null!;

    public string BillingCycle { get; set; } = null!;

    public string? Description { get; set; }

    public int? JobPostingLimit { get; set; }

    public int? FeaturedJobLimit { get; set; }

    public int? CandidateSearchLimit { get; set; }

    public int? ResumeAccessLimit { get; set; }

    public bool? ProfileVisibility { get; set; }

    public bool? PriorityListing { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
