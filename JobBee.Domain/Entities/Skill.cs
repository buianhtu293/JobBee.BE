using System;
using System.Collections.Generic;
using JobBee.Api.Models;

namespace JobBee.Api.Models;

public partial class Skill
{
    public Guid Id { get; set; }

    public string SkillName { get; set; } = null!;

    public Guid? CategoryId { get; set; }

    public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

    public virtual SkillCategory? Category { get; set; }

    public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
}
