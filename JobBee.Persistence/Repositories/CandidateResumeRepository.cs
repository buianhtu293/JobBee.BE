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
	public class CandidateResumeRepository : GenericRepository<CandidateResume, Guid>, ICandidateResumeRepository
	{
		public CandidateResumeRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<List<CandidateResume>> GetCandidateResumeByCandidateId(Guid candidateId)
		{
			return await _context.candidate_resumes
				.Where(r => r.CandidateId == candidateId)
				.ToListAsync();
		}
	}
}
