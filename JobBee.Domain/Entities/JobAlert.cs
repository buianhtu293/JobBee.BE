using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_alert")]
public partial class JobAlert
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("alert_name")]
	public string AlertName { get; set; } = null!;

	[Column("job_category_id")]
	public Guid? JobCategoryId { get; set; }

	[Column("job_type_id")]
	public Guid? JobTypeId { get; set; }

	[Column("location")]
	public string? Location { get; set; }

	[Column("min_salary")]
	public decimal? MinSalary { get; set; }

	[Column("keywords")]
	public string? Keywords { get; set; }

	[Column("frequency")]
	public string Frequency { get; set; } = null!;  // e.g., "daily", "weekly"

	[Column("is_active")]
	public bool? IsActive { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual JobCategory? JobCategory { get; set; }

	public virtual JobType? JobType { get; set; }
}
