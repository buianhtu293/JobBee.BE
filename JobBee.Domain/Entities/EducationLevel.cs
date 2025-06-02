using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("education_level")]
public partial class EducationLevel
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("level_name")]
	public string LevelName { get; set; } = null!;

	public virtual ICollection<CandidateEducation> CandidateEducations { get; set; } = new List<CandidateEducation>();

	public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
