using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using JobBee.Shared.Paginators;

namespace JobBee.Persistence.Repositories
{
	public class JobRepository : GenericRepository<Job, Guid>, IJobRepository
	{
		public JobRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<PageResult<Job>> GetJobAlertByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.JobAlerts.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.JobAlerts,
				j => j.SavedJobs,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}

		public async Task<PageResult<Job>> GetJobsAppliedByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.JobApplications.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}

		public async Task<PageResult<Job>> GetSavedJobByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.SavedJobs.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.SavedJobs,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}
	}
}
