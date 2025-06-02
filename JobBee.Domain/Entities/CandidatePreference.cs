using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_preference")]
public partial class CandidatePreference
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("job_type")]
	public string? JobType { get; set; }

	[Column("remote_preference")]
	public string? RemotePreference { get; set; }

	[Column("min_salary")]
	public decimal? MinSalary { get; set; }

	[Column("preferred_location")]
	public string? PreferredLocation { get; set; }

	[Column("relocation_willingness")]
	public bool? RelocationWillingness { get; set; }

	[Column("travel_willingness")]
	public int? TravelWillingness { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;
}
