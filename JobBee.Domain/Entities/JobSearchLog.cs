using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_search_log")]
public partial class JobSearchLog
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid? UserId { get; set; }

	[Column("search_keyword")]
	public string? SearchKeyword { get; set; }

	[Column("location")]
	public string? Location { get; set; }

	[Column("job_category_id")]
	public Guid? JobCategoryId { get; set; }

	[Column("job_type_id")]
	public Guid? JobTypeId { get; set; }

	[Column("min_salary")]
	public decimal? MinSalary { get; set; }

	[Column("max_salary")]
	public decimal? MaxSalary { get; set; }

	[Column("results_count")]
	public int? ResultsCount { get; set; }

	[Column("search_date")]
	public DateTime? SearchDate { get; set; }

	public virtual JobCategory? JobCategory { get; set; }

	public virtual JobType? JobType { get; set; }

	public virtual User? User { get; set; }
}
