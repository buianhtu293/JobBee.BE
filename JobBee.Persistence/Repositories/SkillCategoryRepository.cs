using JobBee.Api.Models;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;

namespace JobBee.Persistence.Repositories
{
	internal class SkillCategoryRepository : GenericRepository<SkillCategory, Guid>, ISkillCategoryRepository
	{
		public SkillCategoryRepository(JobBeeContext context) : base(context)
		{
		}
	}
}
