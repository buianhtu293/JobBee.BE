namespace JobBee.Domain.Entities;

public partial class CandidatePortfolio
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ProjectUrl { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;
}
