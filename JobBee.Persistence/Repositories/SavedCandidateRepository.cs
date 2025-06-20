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
	public class SavedCandidateRepository : GenericRepository<SavedCandidate, Guid>, ISavedCandidateRepository
	{
		public SavedCandidateRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<SavedCandidate> GetSavedCandidate(Guid EmployerId, Guid CandidateId)
		{
			return await _context.saved_candidates
				.FirstOrDefaultAsync(e => e.EmployerId == EmployerId && e.CandidateId == CandidateId);
		}
	}
}
