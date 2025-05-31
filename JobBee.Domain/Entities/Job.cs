using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("job")]
public partial class Job
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("title")]
	public string Title { get; set; } = null!;

	[Column("job_category_id")]
	public Guid? JobCategoryId { get; set; }

	[Column("job_type_id")]
	public Guid? JobTypeId { get; set; }

	[Column("experience_level_id")]
	public Guid? ExperienceLevelId { get; set; }

	[Column("min_education_id")]
	public Guid? MinEducationId { get; set; }

	[Column("description")]
	public string Description { get; set; } = null!;

	[Column("responsibilities")]
	public string? Responsibilities { get; set; }

	[Column("requirements")]
	public string? Requirements { get; set; }

	[Column("min_salary")]
	public decimal? MinSalary { get; set; }

	[Column("max_salary")]
	public decimal? MaxSalary { get; set; }

	[Column("salary_period")]
	public string? SalaryPeriod { get; set; }

	[Column("currency")]
	public string? Currency { get; set; }

	[Column("is_salary_negotiable")]
	public bool? IsSalaryNegotiable { get; set; }

	[Column("location_city")]
	public string? LocationCity { get; set; }

	[Column("location_state")]
	public string? LocationState { get; set; }

	[Column("location_country")]
	public string? LocationCountry { get; set; }

	[Column("is_remote")]
	public bool? IsRemote { get; set; }

	[Column("allows_work_from_home")]
	public bool? AllowsWorkFromHome { get; set; }

	[Column("application_deadline")]
	public DateOnly? ApplicationDeadline { get; set; }

	[Column("is_featured")]
	public bool? IsFeatured { get; set; }

	[Column("is_active")]
	public bool? IsActive { get; set; }

	[Column("views_count")]
	public int? ViewsCount { get; set; }

	[Column("applications_count")]
	public int? ApplicationsCount { get; set; }

	[Column("posted_at")]
	public DateTime? PostedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	[Column("expires_at")]
	public DateTime? ExpiresAt { get; set; }

	public virtual Employer Employer { get; set; } = null!;

	public virtual ExperienceLevel? ExperienceLevel { get; set; }

	public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

	public virtual JobCategory? JobCategory { get; set; }

	public virtual ICollection<JobSkill> JobSkills { get; set; } = new List<JobSkill>();

	public virtual JobType? JobType { get; set; }

	public virtual EducationLevel? MinEducation { get; set; }

	public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
}
