namespace JobBee.Domain.Entities;

public partial class WebsiteReview
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int Rating { get; set; }

    public string? ReviewText { get; set; }

    public bool? IsFeatured { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
