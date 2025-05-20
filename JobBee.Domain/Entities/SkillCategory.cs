using JobBee.Api.Models;

namespace JobBee.Api.Models;

public partial class SkillCategory
{
	public Guid Id { get; set; }

	public string CategoryName { get; set; } = null!;

	public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
