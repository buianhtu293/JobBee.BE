using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_experience")]
public partial class CandidateExperience
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("company_name")]
	public string CompanyName { get; set; } = null!;

	[Column("position")]
	public string Position { get; set; } = null!;

	[Column("start_date")]
	public DateOnly StartDate { get; set; }

	[Column("end_date")]
	public DateOnly? EndDate { get; set; }

	[Column("is_current")]
	public bool? IsCurrent { get; set; }

	[Column("responsibilities")]
	public string? Responsibilities { get; set; }

	[Column("achievements")]
	public string? Achievements { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;
}
