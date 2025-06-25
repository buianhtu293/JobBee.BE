using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Queries.GetPopularCategory
{
	public class PopularCategoryQuery : IRequest<ApiResponse<PageResult<CategoryPopularDto>>>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
