using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetPostedJobs
{
	public class GetPostedJobQuery : IRequest<ApiResponse<PageResult<PostedJobDto>>>
	{
		public Guid EmployerId { get; set; }
		public String? Keyword { get; set; } = string.Empty;
		public bool? IsActive { get; set; }
		public int Page { get; set; } = 0;
		public int PageSize { get; set; } = 20;
	}
}
