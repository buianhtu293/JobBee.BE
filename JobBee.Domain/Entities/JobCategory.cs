using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class JobCategory
{
    public Guid Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public Guid? ParentCategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<JobCategory> InverseParentCategory { get; set; } = new List<JobCategory>();

    public virtual ICollection<JobAlert> JobAlerts { get; set; } = new List<JobAlert>();

    public virtual ICollection<JobSearchLog> JobSearchLogs { get; set; } = new List<JobSearchLog>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual JobCategory? ParentCategory { get; set; }
}
