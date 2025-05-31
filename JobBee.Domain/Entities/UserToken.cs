using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("user_token")]
public partial class UserToken
{
	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("login_provider")]
	public string LoginProvider { get; set; } = null!;

	[Column("name")]
	public string Name { get; set; } = null!;

	[Column("value")]
	public string? Value { get; set; }

	public virtual User User { get; set; } = null!;
}
