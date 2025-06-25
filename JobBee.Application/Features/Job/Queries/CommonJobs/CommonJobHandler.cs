using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.CommonJobs
{
	public class CommonJobHandler(
		IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
		IMapper mapper
	)
		: IRequestHandler<CommonJobQuery, ApiResponse<PageResult<CommonJob>>>
	{
		public async Task<ApiResponse<PageResult<CommonJob>>> Handle(CommonJobQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = query =>
			{
				return query.OrderByDescending(x => x.ApplicationsCount);
			};

			var jobsDomain = await unitOfWork.GenericRepository.GetPaginatedAsyncIncluding(request.Page, request.PageSize, null, orderBy);
			var commonJobs = mapper.Map<PageResult<CommonJob>>(jobsDomain);
			return new ApiResponse<PageResult<CommonJob>>("Success", 200, commonJobs);
		}
	}
}
