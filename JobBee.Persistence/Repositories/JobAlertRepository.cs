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
	public class JobAlertRepository : GenericRepository<JobAlert, Guid>, IJobAlertRepository
	{
		public JobAlertRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<JobAlert> GetJobAlert(Guid candidateId, Guid jobId)
		{
			return await _context.job_alerts
					.FirstOrDefaultAsync(sj => sj.CandidateId == candidateId && sj.JobId == jobId);
		}
	}
}
