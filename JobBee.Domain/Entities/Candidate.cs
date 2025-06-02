using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("candidate")]
public partial class Candidate
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("first_name")]
	public string? FirstName { get; set; }

	[Column("last_name")]
	public string? LastName { get; set; }

	[Column("profile_picture")]
	public string? ProfilePicture { get; set; }

	[Column("phone")]
	public string? Phone { get; set; }

	[Column("birth_date")]
	public DateOnly? BirthDate { get; set; }

	[Column("gender")]
	public string? Gender { get; set; }

	[Column("address")]
	public string? Address { get; set; }

	[Column("city")]
	public string? City { get; set; }

	[Column("state")]
	public string? State { get; set; }

	[Column("country")]
	public string? Country { get; set; }

	[Column("postal_code")]
	public string? PostalCode { get; set; }

	[Column("headline")]
	public string? Headline { get; set; }

	[Column("summary")]
	public string? Summary { get; set; }

	[Column("current_salary")]
	public decimal? CurrentSalary { get; set; }

	[Column("salary_expectation")]
	public decimal? SalaryExpectation { get; set; }

	[Column("experience_years")]
	public int? ExperienceYears { get; set; }

	[Column("is_available_for_hire")]
	public bool? IsAvailableForHire { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<CandidateEducation> CandidateEducations { get; set; } = new List<CandidateEducation>();
	public virtual ICollection<CandidateExperience> CandidateExperiences { get; set; } = new List<CandidateExperience>();
	public virtual ICollection<CandidatePortfolio> CandidatePortfolios { get; set; } = new List<CandidatePortfolio>();
	public virtual CandidatePreference? CandidatePreference { get; set; }
	public virtual ICollection<CandidateResume> CandidateResumes { get; set; } = new List<CandidateResume>();
	public virtual ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();
	public virtual ICollection<EmployerReview> EmployerReviews { get; set; } = new List<EmployerReview>();
	public virtual ICollection<JobAlert> JobAlerts { get; set; } = new List<JobAlert>();
	public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
	public virtual ICollection<SavedCandidate> SavedCandidates { get; set; } = new List<SavedCandidate>();
	public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
	public virtual User User { get; set; } = null!;
}
