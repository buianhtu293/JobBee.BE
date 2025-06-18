using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ICandidateRepository : IGenericRepository<Candidate, Guid>
	{
		Task<PageResult<Candidate>> GetCandidateAppliedByJobAsync(Guid jobId, int pageIndex, int pageSize, CancellationToken cancellationToken);
	}
}
