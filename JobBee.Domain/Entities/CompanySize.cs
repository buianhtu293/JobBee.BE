using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("company_size")]
public partial class CompanySize
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("size_range")]
	public string SizeRange { get; set; } = null!;

	public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
