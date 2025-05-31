using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("role_claim")]
public partial class RoleClaim
{
	[Column("id")]
	public int Id { get; set; }

	[Column("role_id")]
	public Guid RoleId { get; set; }

	[Column("claim_type")]
	public string? ClaimType { get; set; }

	[Column("claim_value")]
	public string? ClaimValue { get; set; }

	public virtual Role Role { get; set; } = null!;
}
