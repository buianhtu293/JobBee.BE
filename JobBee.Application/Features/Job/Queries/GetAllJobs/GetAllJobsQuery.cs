using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class GetAllJobsQuery : IRequest<ApiResponse<PageResult<JobDto>>>
	{
		public String? Keyword { get; set; } = string.Empty;
		public String? Location { get; set; }
		public IList<String>? Categories { get; set; } = new List<String>();
		public String? Experience { get; set; }
		public decimal? MinSalary { get; set; }
		public decimal? MaxSalary { get; set; }
		public IList<String>? JobTypes { get; set; } = new List<String>();
		public List<String>? EducationLevels { get; set; } = new List<String>();
		public String? Level { get; set; }
		public int Page { get; set; } = 0;
		public int PageSize { get; set; } = 20;
	}
}
