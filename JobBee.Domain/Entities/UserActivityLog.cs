namespace JobBee.Domain.Entities;

public partial class UserActivityLog
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string ActivityType { get; set; } = null!;

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public string? Details { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
