using JobBee.Application.Features.Employer.Commands.CreateEmployer;

namespace JobBee.Application.Features.Employer.Queries.GetEmployerDetail
{
	public class EmployerDetailDTO
	{
		public Guid EmployerId { get; set; }
		public string CompanyLogo { get; set; } = null!;
		public string CompanyName { get; set; } = null!;
		public string Industry { get; set; } = null!;
		public string CompanySize { get; set; } = null!;
		public string ContactPhone { get; set; } = null!;
		public string ContactEmail { get; set; } = null!;
		public string WebsiteUrl { get; set; } = null!;
		public List<SocialMedial> SocialMedials { get; set; }
	}
}
