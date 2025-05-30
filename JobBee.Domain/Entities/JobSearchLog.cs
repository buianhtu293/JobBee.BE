using JobBee.Api.Models;

namespace JobBee.Domain.Entities;

public partial class JobSearchLog
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string? SearchKeyword { get; set; }

    public string? Location { get; set; }

    public Guid? JobCategoryId { get; set; }

    public Guid? JobTypeId { get; set; }

    public decimal? MinSalary { get; set; }

    public decimal? MaxSalary { get; set; }

    public int? ResultsCount { get; set; }

    public DateTime? SearchDate { get; set; }

    public virtual JobCategory? JobCategory { get; set; }

    public virtual JobType? JobType { get; set; }

    public virtual User? User { get; set; }
}
