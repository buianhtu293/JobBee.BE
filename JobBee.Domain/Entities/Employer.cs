using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("employer")]
public partial class Employer
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("company_name")]
	public string CompanyName { get; set; } = null!;

	[Column("company_logo")]
	public string? CompanyLogo { get; set; }

	[Column("industry_id")]
	public Guid? IndustryId { get; set; }

	[Column("company_size_id")]
	public Guid? CompanySizeId { get; set; }

	[Column("founded_year")]
	public int? FoundedYear { get; set; }

	[Column("company_description")]
	public string? CompanyDescription { get; set; }

	[Column("website_url")]
	public string? WebsiteUrl { get; set; }

	[Column("headquarters_address")]
	public string? HeadquartersAddress { get; set; }

	[Column("headquarters_city")]
	public string? HeadquartersCity { get; set; }

	[Column("headquarters_state")]
	public string? HeadquartersState { get; set; }

	[Column("headquarters_country")]
	public string? HeadquartersCountry { get; set; }

	[Column("contact_person_name")]
	public string? ContactPersonName { get; set; }

	[Column("contact_email")]
	public string? ContactEmail { get; set; }

	[Column("contact_phone")]
	public string? ContactPhone { get; set; }

	[Column("is_verified")]
	public bool? IsVerified { get; set; }

	[Column("verification_documents")]
	public string? VerificationDocuments { get; set; }

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual ICollection<CompanyPhoto> CompanyPhotos { get; set; } = new List<CompanyPhoto>();

	public virtual CompanySize? CompanySize { get; set; }

	public virtual ICollection<EmployerBenefit> EmployerBenefits { get; set; } = new List<EmployerBenefit>();

	public virtual ICollection<EmployerReview> EmployerReviews { get; set; } = new List<EmployerReview>();

	public virtual ICollection<EmployerSocialMedia> EmployerSocialMedia { get; set; } = new List<EmployerSocialMedia>();

	public virtual Industry? Industry { get; set; }

	public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

	public virtual ICollection<SavedCandidate> SavedCandidates { get; set; } = new List<SavedCandidate>();

	public virtual User User { get; set; } = null!;
}
