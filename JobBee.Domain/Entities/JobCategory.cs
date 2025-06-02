using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_category")]
public partial class JobCategory
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("category_name")]
	public string CategoryName { get; set; } = null!;

	[Column("parent_category_id")]
	public Guid? ParentCategoryId { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	// Collection of child categories
	public virtual ICollection<JobCategory> InverseParentCategory { get; set; } = new List<JobCategory>();

	// Navigation for related JobAlerts with this category
	public virtual ICollection<JobAlert> JobAlerts { get; set; } = new List<JobAlert>();

	// Navigation for related JobSearchLogs with this category
	public virtual ICollection<JobSearchLog> JobSearchLogs { get; set; } = new List<JobSearchLog>();

	// Navigation for Jobs under this category
	public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

	// Navigation for parent category
	public virtual JobCategory? ParentCategory { get; set; }
}
