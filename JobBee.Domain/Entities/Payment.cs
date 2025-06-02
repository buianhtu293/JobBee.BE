using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("payment")]
public partial class Payment
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("subscription_id")]
	public Guid? SubscriptionId { get; set; }

	[Column("amount")]
	public decimal Amount { get; set; }

	[Column("currency")]
	public string Currency { get; set; } = null!;

	[Column("payment_method")]
	public string PaymentMethod { get; set; } = null!;

	[Column("transaction_id")]
	public string? TransactionId { get; set; }

	[Column("status")]
	public string Status { get; set; } = null!;

	[Column("payment_date")]
	public DateTime? PaymentDate { get; set; }

	[Column("description")]
	public string? Description { get; set; }

	public virtual Subscription? Subscription { get; set; }

	public virtual User User { get; set; } = null!;
}
