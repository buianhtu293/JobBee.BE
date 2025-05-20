using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class EmailTemplate
{
    public Guid Id { get; set; }

    public string TemplateName { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string? Variables { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<EmailLog> EmailLogs { get; set; } = new List<EmailLog>();
}
