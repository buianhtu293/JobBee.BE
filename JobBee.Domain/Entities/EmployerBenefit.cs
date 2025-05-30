namespace JobBee.Domain.Entities;

public partial class EmployerBenefit
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public string BenefitName { get; set; } = null!;

    public string? BenefitDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Employer Employer { get; set; } = null!;
}
