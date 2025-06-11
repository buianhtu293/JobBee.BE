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
	public class EducationLevelRepository : GenericRepository<EducationLevel, Guid>, IEducationLevelRepository
	{
		public EducationLevelRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<EducationLevel?> GetByName(string EducationLevelName)
		{
			return await _context.education_levels.FirstOrDefaultAsync(q => q.LevelName == EducationLevelName);
		}

		public async Task<bool> IsEducationLevelUnique(string EducationLevelName)
		{
			return await _context.education_levels.AnyAsync(q => q.LevelName == EducationLevelName) == false;
		}
	}
}
