using JobBee.Api.Models;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;

namespace JobBee.Persistence.Repositories
{
	public class SkillCategoryRepository : GenericRepository<SkillCategory, Guid>, ISkillCategoryRepository
	{
		public SkillCategoryRepository(JobBeeContext context) : base(context)
		{
		}
	}
}
