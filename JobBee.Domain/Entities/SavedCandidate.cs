using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class SavedCandidate
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public Guid CandidateId { get; set; }

    public DateTime? SavedAt { get; set; }

    public string? Notes { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Employer Employer { get; set; } = null!;
}
