using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;
using MediatR;
using System.Linq;


namespace JobBee.Application.Features.Job.Queries.GetPostedJobs
{
	public class GetPostedJobQueryHandler(
		IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
		IMapper mapper
	) : IRequestHandler<GetPostedJobQuery, ApiResponse<PageResult<PostedJobDto>>>
	{
		public async Task<ApiResponse<PageResult<PostedJobDto>>> Handle(GetPostedJobQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>> filter = query =>
			{
				if (request == null) return query;

				query = query.Where(job => job.EmployerId == request.EmployerId);

				if (!string.IsNullOrWhiteSpace(request.Keyword))
				{
					string keyword = request.Keyword.Trim().ToLower();
					query = query.Where(job =>
						job.Title.ToLower().Contains(keyword) ||
						job.Description.ToLower().Contains(keyword));
				}

				if (request.IsActive.HasValue)
				{
					query = query.Where(job => job.IsActive == request.IsActive.Value);
				}

				return query;
			};

			var pageResult = await unitOfWork.GenericRepository.GetPaginatedAsyncIncluding(
				request.Page,
				request.PageSize,
				filter,
				null,
				c => c.JobType!
			);

			return new ApiResponse<PageResult<PostedJobDto>>("Success", 200, mapper.Map<PageResult<PostedJobDto>>(pageResult));
		}
	}
}
