using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class CandidateEducation
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string InstitutionName { get; set; } = null!;

    public Guid? EducationLevelId { get; set; }

    public string? FieldOfStudy { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? IsCurrent { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual EducationLevel? EducationLevel { get; set; }
}
