namespace JobBee.Domain.Entities;

public partial class SkillCategory
{
	public Guid Id { get; set; }

	public string CategoryName { get; set; } = null!;

	public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
