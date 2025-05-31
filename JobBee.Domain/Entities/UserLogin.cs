using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("user_login")]
public partial class UserLogin
{
	[Column("login_provider")]
	public string LoginProvider { get; set; } = null!;

	[Column("provider_key")]
	public string ProviderKey { get; set; } = null!;

	[Column("provider_display_name")]
	public string? ProviderDisplayName { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	public virtual User User { get; set; } = null!;
}
