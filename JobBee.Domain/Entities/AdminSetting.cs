using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Domain.Entities;

[Table("admin_setting")]
public partial class AdminSetting
{
	[Column("id")]
	public Guid Id { get; set; }

	[Column("setting_name")]
	public string SettingName { get; set; } = null!;

	[Column("setting_value")]
	public string SettingValue { get; set; } = null!;

	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }

	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }
}