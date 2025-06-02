using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("role")]
public partial class Role
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("name")]
	public string? Name { get; set; }

	[Column("normalized_name")]
	public string? NormalizedName { get; set; }

	[Column("concurrency_stamp")]
	public string? ConcurrencyStamp { get; set; }

	public virtual ICollection<RoleClaim> RoleClaims { get; set; } = new List<RoleClaim>();

	public virtual ICollection<User> Users { get; set; } = new List<User>();
}
