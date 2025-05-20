using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class JobApplication
{
    public Guid Id { get; set; }

    public Guid JobId { get; set; }

    public Guid CandidateId { get; set; }

    public Guid? ResumeId { get; set; }

    public string? CoverLetter { get; set; }

    public string Status { get; set; } = null!;

    public string? EmployerNotes { get; set; }

    public DateTime? AppliedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual CandidateResume? Resume { get; set; }
}
