using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class CompanySize
{
    public Guid Id { get; set; }

    public string SizeRange { get; set; } = null!;

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
