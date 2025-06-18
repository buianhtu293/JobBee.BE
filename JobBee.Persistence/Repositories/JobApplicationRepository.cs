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
	public class JobApplicationRepository : GenericRepository<JobApplication, Guid>, IJobApplicationRepository
	{
		public JobApplicationRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<List<JobApplication>> GetJobApplicationByCandidateId(Guid candidateId)
		{
			return await _context.job_applications
				.Where(c => c.CandidateId == candidateId)
				.ToListAsync();
		}

		public async Task<List<JobApplication>> GetJobApplicationByJobId(Guid jobId)
		{
			return await _context.job_applications
				.Where(j => j.JobId == jobId)
				.ToListAsync();
		}
	}
}
