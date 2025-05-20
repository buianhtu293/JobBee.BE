using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class EmployerReview
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public Guid CandidateId { get; set; }

    public int Rating { get; set; }

    public string? Title { get; set; }

    public string? ReviewText { get; set; }

    public string? Pros { get; set; }

    public string? Cons { get; set; }

    public bool? IsAnonymous { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Employer Employer { get; set; } = null!;
}
