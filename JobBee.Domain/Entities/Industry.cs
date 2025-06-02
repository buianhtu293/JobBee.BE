using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("industry")]
public partial class Industry
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("industry_name")]
	public string IndustryName { get; set; } = null!;

	public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
