using JobBee.Application.Features.Employer.Queries.GetEmployerDetail;

namespace JobBee.Application.Features.Job.Queries.GetDetail
{
	public class JobDetailDto
	{
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Responsibility { get; set; } = null!;
		public DateTime PostedAt { get; set; }
		public long ApplicationDeadline { get; set; }
		public string Level { get; set; } = null!;
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }
		public string LocationCity { get; set; } = null!;
		public string JobType { get; set; } = null!;
		public string Experience { get; set; } = null!;
		public EmployerDetailDTO Employer { get; set; } = new EmployerDetailDTO();
	}
}
