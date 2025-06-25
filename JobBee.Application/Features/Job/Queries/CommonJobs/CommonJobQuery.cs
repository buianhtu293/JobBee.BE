using Elastic.Clients.Elasticsearch.MachineLearning;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.CommonJobs
{
	public class CommonJobQuery : IRequest<ApiResponse<PageResult<CommonJob>>>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
