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
	public class CandidateEducationRepository : GenericRepository<CandidateEducation, Guid>, ICandidateEducationRepository
	{
		public CandidateEducationRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<List<CandidateEducation>> GetCandidateEducationByCandidateId(Guid CandidateId)
		{
			return await _context.candidate_educations
				.Where(ce => ce.CandidateId == CandidateId)
				.ToListAsync();
		}
	}
}
