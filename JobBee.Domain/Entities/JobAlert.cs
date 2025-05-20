using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class JobAlert
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string AlertName { get; set; } = null!;

    public Guid? JobCategoryId { get; set; }

    public Guid? JobTypeId { get; set; }

    public string? Location { get; set; }

    public decimal? MinSalary { get; set; }

    public string? Keywords { get; set; }

    public string Frequency { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual JobCategory? JobCategory { get; set; }

    public virtual JobType? JobType { get; set; }
}
