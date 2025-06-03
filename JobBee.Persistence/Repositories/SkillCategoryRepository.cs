using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class SkillCategoryRepository : GenericRepository<SkillCategory, Guid>, ISkillCategoryRepository
	{
		public SkillCategoryRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<SkillCategory?> GetByName(string CategoryName)
		{
			return await _context.skill_categories.FirstOrDefaultAsync(q => q.CategoryName == CategoryName);
		}

		public async Task<bool> IsSkillCategoryUnique(string CategoryName)
		{
			return await _context.skill_categories.AnyAsync(q => q.CategoryName == CategoryName) == false;
		}
	}
}
