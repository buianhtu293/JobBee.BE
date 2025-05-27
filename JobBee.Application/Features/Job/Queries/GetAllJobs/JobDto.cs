using JobBee.Application.Features.Company;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class JobDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = null!;
		public string Location { get; set; } = null!;
		public string JobType { get; set; } = null!;
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }
		public bool IsFeatured { get; set; }
		public CompanyDto Company { get; set; } = null!;
	}
}
