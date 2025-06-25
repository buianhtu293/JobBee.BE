namespace JobBee.Application.Features.Company.Queries.GetTopCompany
{
	public class TopCompanyDto
	{
		public Guid Id { get; set; }
		public string CompanyName { get; set; } = null!;
		public string HeadquartersCity { get; set; } = null!;
		public string CompanyLogo { get; set; } = null!;
	}
}
