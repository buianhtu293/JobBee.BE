using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;
using MediatR;
using static Amazon.S3.Util.S3EventNotification;

namespace JobBee.Application.Features.Company.Queries.GetTopCompany
{
	public class TopCompanyQueryHandler(
		IUnitOfWork<Domain.Entities.Employer, Guid> unitOfWork,
		IMapper mapper
	)
		: IRequestHandler<TopCompanyQuery, ApiResponse<PageResult<TopCompanyDto>>>
	{
		public async Task<ApiResponse<PageResult<TopCompanyDto>>> Handle(TopCompanyQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Employer>, IOrderedQueryable<Domain.Entities.Employer>>? orderBy = query =>
			{
				return query.OrderByDescending(e => e.Jobs.Count);
			};
			var companies = await unitOfWork.GenericRepository.GetPaginatedAsyncIncluding(request.Page, request.PageSize, null, orderBy, e => e.Jobs);
			return new ApiResponse<PageResult<TopCompanyDto>>("Success", 200, mapper.Map<PageResult<TopCompanyDto>>(companies));
		}
	}
}
