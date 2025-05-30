using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class CompanyPhoto
{
    public Guid Id { get; set; }

    public Guid EmployerId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public string? Caption { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Employer Employer { get; set; } = null!;
}
