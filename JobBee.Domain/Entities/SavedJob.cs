namespace JobBee.Domain.Entities;

public partial class SavedJob
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public Guid JobId { get; set; }

    public DateTime? SavedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;
}
