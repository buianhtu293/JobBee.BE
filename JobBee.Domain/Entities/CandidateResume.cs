using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_resume")]
public partial class CandidateResume
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("file_name")]
	public string FileName { get; set; } = null!;

	[Column("file_path")]
	public string FilePath { get; set; } = null!;

	[Column("file_size")]
	public int FileSize { get; set; }

	[Column("file_type")]
	public string FileType { get; set; } = null!;

	[Column("is_default")]
	public bool? IsDefault { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}
