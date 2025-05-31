using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("employer_social_media")]
public partial class EmployerSocialMedia
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("employer_id")]
	public Guid EmployerId { get; set; }

	[Column("platform_name")]
	public string PlatformName { get; set; } = null!;

	[Column("profile_url")]
	public string ProfileUrl { get; set; } = null!;

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	public virtual Employer Employer { get; set; } = null!;
}
