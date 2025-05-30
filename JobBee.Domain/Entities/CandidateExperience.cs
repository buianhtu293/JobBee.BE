namespace JobBee.Domain.Entities;

public partial class CandidateExperience
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsCurrent { get; set; }

    public string? Responsibilities { get; set; }

    public string? Achievements { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;
}
