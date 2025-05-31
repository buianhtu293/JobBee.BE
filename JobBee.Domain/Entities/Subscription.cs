using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("subscription")]
public partial class Subscription
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("plan_id")]
	public Guid PlanId { get; set; }

	[Column("status")]
	public string Status { get; set; } = null!;

	[Column("start_date")]
	public DateTime StartDate { get; set; }

	[Column("end_date")]
	public DateTime? EndDate { get; set; }

	[Column("renewal_date")]
	public DateTime? RenewalDate { get; set; }

	[Column("payment_method")]
	public string? PaymentMethod { get; set; }

	[Column("auto_renew")]
	public bool? AutoRenew { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

	public virtual SubscriptionPlan Plan { get; set; } = null!;

	public virtual User User { get; set; } = null!;
}
