using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("skill_category")]
public partial class SkillCategory
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("category_name")]
	public string CategoryName { get; set; } = null!;

	public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
