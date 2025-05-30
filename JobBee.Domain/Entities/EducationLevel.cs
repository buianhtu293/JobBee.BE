using System;
using System.Collections.Generic;
using JobBee.Domain.Entities;

namespace JobBee.Api.Models;

public partial class EducationLevel
{
    public Guid Id { get; set; }

    public string LevelName { get; set; } = null!;

    public virtual ICollection<CandidateEducation> CandidateEducations { get; set; } = new List<CandidateEducation>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
