namespace JobBee.Domain.Entities;

public partial class ExperienceLevel
{
    public Guid Id { get; set; }

    public string LevelName { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
