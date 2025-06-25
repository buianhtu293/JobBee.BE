using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Company.Queries.GetTopCompany
{
	public class TopCompanyQuery : IRequest<ApiResponse<PageResult<TopCompanyDto>>>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
