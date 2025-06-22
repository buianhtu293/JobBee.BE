using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class SavedJobRepository : GenericRepository<SavedJob, Guid>, ISavedJobRepository
	{
		public SavedJobRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<SavedJob> GetSavedJob(Guid candidateId, Guid jobId)
		{
			return await _context.saved_jobs
					.FirstOrDefaultAsync(sj => sj.CandidateId == candidateId && sj.JobId == jobId);
		}
	}
}
