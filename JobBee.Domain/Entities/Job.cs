using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class Job
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public string Title { get; set; } = null!;

    public Guid? JobCategoryId { get; set; }

    public Guid? JobTypeId { get; set; }

    public Guid? ExperienceLevelId { get; set; }

    public Guid? MinEducationId { get; set; }

    public string Description { get; set; } = null!;

    public string? Responsibilities { get; set; }

    public string? Requirements { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public string? SalaryPeriod { get; set; }

    public string? Currency { get; set; }

    public bool? IsSalaryNegotiable { get; set; }

    public string? LocationCity { get; set; }

    public string? LocationState { get; set; }

    public string? LocationCountry { get; set; }

    public bool? IsRemote { get; set; }

    public bool? AllowsWorkFromHome { get; set; }

    public DateOnly? ApplicationDeadline { get; set; }

    public bool? IsFeatured { get; set; }

    public bool? IsActive { get; set; }

    public int? ViewsCount { get; set; }

    public int? ApplicationsCount { get; set; }

    public DateTime? PostedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

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
