using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("user_claim")]
public partial class UserClaim
{
	[Column("id")]
	public int Id { get; set; }

	[Column("user_id")]
	public Guid UserId { get; set; }

	[Column("claim_type")]
	public string? ClaimType { get; set; }

	[Column("claim_value")]
	public string? ClaimValue { get; set; }

	public virtual User User { get; set; } = null!;
}
