using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class ReportedContent
{
    public Guid Id { get; set; }

    public Guid ReporterUserId { get; set; }

    public string ContentType { get; set; } = null!;

    public int ContentId { get; set; }

    public string Reason { get; set; } = null!;

    public string? Details { get; set; }

    public string? Status { get; set; }

    public string? AdminNotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User ReporterUser { get; set; } = null!;
}
