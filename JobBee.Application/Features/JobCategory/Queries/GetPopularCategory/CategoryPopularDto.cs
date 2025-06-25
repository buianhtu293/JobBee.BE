namespace JobBee.Application.Features.JobCategory.Queries.GetPopularCategory
{
	public class CategoryPopularDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
		public int OpenPosition { get; set; }
	}
}
