namespace JobBee.Domain.Entities;

public partial class JobType
{
    public Guid Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<JobAlert> JobAlerts { get; set; } = new List<JobAlert>();

    public virtual ICollection<JobSearchLog> JobSearchLogs { get; set; } = new List<JobSearchLog>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
