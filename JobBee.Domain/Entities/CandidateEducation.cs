using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate_education")]
public partial class CandidateEducation
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("candidate_id")]
	public Guid CandidateId { get; set; }

	[Column("institution_name")]
	public string InstitutionName { get; set; } = null!;

	[Column("education_level_id")]
	public Guid? EducationLevelId { get; set; }

	[Column("field_of_study")]
	public string? FieldOfStudy { get; set; }

	[Column("start_date")]
	public DateOnly? StartDate { get; set; }

	[Column("end_date")]
	public DateOnly? EndDate { get; set; }

	[Column("is_current")]
	public bool? IsCurrent { get; set; }

	[Column("description")]
	public string? Description { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Candidate Candidate { get; set; } = null!;

	public virtual EducationLevel? EducationLevel { get; set; }
}
