using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using JobBee.Shared.Paginators;

namespace JobBee.Persistence.Repositories
{
	public class CandidateRepository : GenericRepository<Candidate, Guid>, ICandidateRepository
	{
		public CandidateRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<PageResult<Candidate>> GetCandidateAppliedByJobAsync(Guid jobId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Candidate>, IQueryable<Domain.Entities.Candidate>>? filter = null;
			filter = query => query.Where(j => j.JobApplications.Any(ja => ja.JobId == jobId));

			Func<IQueryable<Domain.Entities.Candidate>, IOrderedQueryable<Domain.Entities.Candidate>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.User
				);
		}
	}
}
