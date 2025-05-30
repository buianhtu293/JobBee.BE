namespace JobBee.Domain.Entities;

public partial class Industry
{
    public Guid Id { get; set; }

    public string IndustryName { get; set; } = null!;

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
