using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class Employer
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyLogo { get; set; }

    public Guid? IndustryId { get; set; }

    public Guid? CompanySizeId { get; set; }

    public int? FoundedYear { get; set; }

    public string? CompanyDescription { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? HeadquartersAddress { get; set; }

    public string? HeadquartersCity { get; set; }

    public string? HeadquartersState { get; set; }

    public string? HeadquartersCountry { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public bool? IsVerified { get; set; }

    public string? VerificationDocuments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CompanyPhoto> CompanyPhotos { get; set; } = new List<CompanyPhoto>();

    public virtual CompanySize? CompanySize { get; set; }

    public virtual ICollection<EmployerBenefit> EmployerBenefits { get; set; } = new List<EmployerBenefit>();

    public virtual ICollection<EmployerReview> EmployerReviews { get; set; } = new List<EmployerReview>();

    public virtual ICollection<EmployerSocialMedium> EmployerSocialMedia { get; set; } = new List<EmployerSocialMedium>();

    public virtual Industry? Industry { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual ICollection<SavedCandidate> SavedCandidates { get; set; } = new List<SavedCandidate>();

    public virtual User User { get; set; } = null!;
}
