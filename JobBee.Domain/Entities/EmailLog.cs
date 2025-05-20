using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class EmailLog
{
    public Guid Id { get; set; }

    public string RecipientEmail { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public Guid? TemplateId { get; set; }

    public DateTime? SentAt { get; set; }

    public string Status { get; set; } = null!;

    public string? ErrorMessage { get; set; }

    public virtual EmailTemplate? Template { get; set; }
}
