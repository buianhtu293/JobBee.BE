using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job_type")]
public partial class JobType
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("type_name")]
	public string TypeName { get; set; } = null!;

	public virtual ICollection<JobSearchLog> JobSearchLogs { get; set; } = new List<JobSearchLog>();

	public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
