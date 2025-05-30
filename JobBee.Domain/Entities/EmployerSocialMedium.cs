namespace JobBee.Domain.Entities;

public partial class EmployerSocialMedium
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public string PlatformName { get; set; } = null!;

    public string ProfileUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employer Employer { get; set; } = null!;
}
