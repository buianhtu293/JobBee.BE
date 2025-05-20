using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class NotificationType
{
    public Guid Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Template { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
