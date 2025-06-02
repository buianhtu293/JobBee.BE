using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("skill")]
public partial class Skill
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("skill_name")]
	public string SkillName { get; set; } = null!;

	[Column("category_id")]
	public Guid? CategoryId { get; set; }

	public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

	public virtual SkillCategory? Category { get; set; }

	public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();
}
