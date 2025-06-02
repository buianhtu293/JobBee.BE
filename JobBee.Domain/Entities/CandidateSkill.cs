using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_skill")]
public partial class CandidateSkill
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("skill_id")]
	public Guid SkillId { get; set; }

	[Column("proficiency_level")]
	public int? ProficiencyLevel { get; set; }

	[Column("years_experience")]
	public int? YearsExperience { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual Skill Skill { get; set; } = null!;
}
