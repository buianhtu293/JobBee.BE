namespace JobBee.Application.Features.Company
{
	public class CompanyDto
	{
		public Guid Id { get; set; }
		public string Image { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Location { get; set; } = null!;
		public int OpenJobs { get; set; } = 0;
	}
}
