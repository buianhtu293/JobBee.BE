using System;
using System.Collections.Generic;

namespace JobBee.Api.Models;

public partial class Candidate
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ProfilePicture { get; set; }

    public string? Phone { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Headline { get; set; }

    public string? Summary { get; set; }

    public decimal? CurrentSalary { get; set; }

    public decimal? SalaryExpectation { get; set; }

    public int? ExperienceYears { get; set; }

    public bool? IsAvailableForHire { get; set; }

    public DateTime? CreatedAt { get; set; }

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
