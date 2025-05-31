using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("company_photo")]
public partial class CompanyPhoto
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("photo_url")]
	public string PhotoUrl { get; set; } = null!;

	[Column("caption")]
	public string? Caption { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	public virtual Employer Employer { get; set; } = null!;
}
