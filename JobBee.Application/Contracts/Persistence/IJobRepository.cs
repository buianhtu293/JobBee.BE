using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IJobRepository : IGenericRepository<Job, Guid>
	{
		Task<PageResult<Job>> GetJobsAppliedByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken);
		Task<PageResult<Job>> GetSavedJobByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken);
		Task<PageResult<Job>> GetJobAlertByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken);
	}
}
