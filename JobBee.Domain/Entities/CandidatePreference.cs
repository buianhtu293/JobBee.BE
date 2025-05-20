using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class CandidatePreference
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string? JobType { get; set; }

    public string? RemotePreference { get; set; }

    public decimal? MinSalary { get; set; }

    public string? PreferredLocation { get; set; }

    public bool? RelocationWillingness { get; set; }

    public int? TravelWillingness { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;
}
