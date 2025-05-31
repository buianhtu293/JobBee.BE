using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_skill")]
public partial class JobSkill
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("job_id")]
	public Guid JobId { get; set; }

	[Column("skill_id")]
	public Guid SkillId { get; set; }

	[Column("is_required")]
	public bool? IsRequired { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual Job Job { get; set; } = null!;

	public virtual Skill Skill { get; set; } = null!;
}
