using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("experience_level")]
public partial class ExperienceLevel
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("level_name")]
	public string LevelName { get; set; } = null!;

	public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
