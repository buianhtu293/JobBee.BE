using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;
using static Amazon.S3.Util.S3EventNotification;

namespace JobBee.Application.Features.JobCategory.Queries.GetPopularCategory
{
	public class PopularCategoryQueryHandler(
		IUnitOfWork<Domain.Entities.JobCategory, Guid> unitOfWork,
		IMapper mapper
	)
		: IRequestHandler<PopularCategoryQuery, ApiResponse<PageResult<CategoryPopularDto>>>
	{
		public async Task<ApiResponse<PageResult<CategoryPopularDto>>> Handle(PopularCategoryQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.JobCategory>, IOrderedQueryable<Domain.Entities.JobCategory>>? orderBy = query =>
			{
				return query.OrderByDescending(c => c.Jobs.Count);
			};
			var jobCategorys = await unitOfWork.GenericRepository.GetPaginatedAsyncIncluding(request.Page, request.PageSize, null, orderBy, c => c.Jobs);
			return new ApiResponse<PageResult<CategoryPopularDto>>("Success", 200, mapper.Map<PageResult<CategoryPopularDto>>(jobCategorys));
		}
	}
}
