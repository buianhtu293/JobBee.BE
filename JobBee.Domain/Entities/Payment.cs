using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class Payment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid? SubscriptionId { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public string? Description { get; set; }

    public virtual Subscription? Subscription { get; set; }

    public virtual User User { get; set; } = null!;
}
