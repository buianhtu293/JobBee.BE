using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;


namespace JobBee.Application.Features.Job.Queries.GetPostedJobs
{
	public class GetPostedJobQueryHandler(
		IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
		IMapper mapper
	) : IRequestHandler<GetPostedJobQuery, ApiResponse<PageResult<PostedJobDto>>>
	{
		public async Task<ApiResponse<PageResult<PostedJobDto>>> Handle(GetPostedJobQuery request, CancellationToken cancellationToken)
		{
			var query = unitOfWork.GenericRepository
				.GetQueryAble();

			query = query.Where(x => x.EmployerId == request.EmployerId);

			if (!string.IsNullOrWhiteSpace(request.Keyword))
			{
				string keyword = request.Keyword.Trim().ToLower();
				query = query.Where(j =>
					j.Title.ToLower().Contains(keyword) ||
					j.Description.ToLower().Contains(keyword));
			}

			if (request.IsActive.HasValue)
			{
				query = query.Where(j => j.IsActive == request.IsActive.Value);
			}

			int totalCount = query.Count();

			var pagedJobs = query
				.OrderByDescending(j => j.PostedAt)
				.Skip(request.Page * request.PageSize)
				.Take(request.PageSize)
				.ToList();

			var jobDtos = mapper.Map<List<PostedJobDto>>(pagedJobs);

			var pageResult = new PageResult<PostedJobDto>(jobDtos, totalCount, request.Page, request.PageSize);
			return new ApiResponse<PageResult<PostedJobDto>>("Success", 200, pageResult);
		}
	}
}
