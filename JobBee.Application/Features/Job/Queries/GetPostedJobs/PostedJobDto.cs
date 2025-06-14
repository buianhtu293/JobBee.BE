namespace JobBee.Application.Features.Job.Queries.GetPostedJobs
{
	public class PostedJobDto
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = null!;
		public string JobType { get; set; } = null!;
		public int DaysRemaing { get; set; }
		public bool IsActive { get; set; }
		public int Application { get; set; }
	}
}
