using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class CandidateResume
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int FileSize { get; set; }

    public string FileType { get; set; } = null!;

    public bool? IsDefault { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}
