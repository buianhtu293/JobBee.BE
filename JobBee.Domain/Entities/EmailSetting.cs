using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class EmailSetting
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool? JobAlerts { get; set; }

    public bool? ApplicationUpdates { get; set; }

    public bool? ProfileViews { get; set; }

    public bool? JobRecommendations { get; set; }

    public bool? MarketingEmails { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
