using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("employer_benefit")]
public partial class EmployerBenefit
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("benefit_name")]
	public string BenefitName { get; set; } = null!;

	[Column("benefit_description")]
	public string? BenefitDescription { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Employer Employer { get; set; } = null!;
}
