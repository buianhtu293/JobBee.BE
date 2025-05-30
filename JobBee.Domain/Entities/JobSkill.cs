using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class JobSkill
{
    public Guid Id { get; set; }

    public Guid JobId { get; set; }

    public Guid SkillId { get; set; }

    public bool? IsRequired { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
