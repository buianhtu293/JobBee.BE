using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class CandidateSkill
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public Guid SkillId { get; set; }

    public int? ProficiencyLevel { get; set; }

    public int? YearsExperience { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
