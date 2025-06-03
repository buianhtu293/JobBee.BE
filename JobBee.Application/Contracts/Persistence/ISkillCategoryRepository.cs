using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ISkillCategoryRepository : IGenericRepository<SkillCategory, Guid>
	{
		Task<bool> IsSkillCategoryUnique(string CategoryName);
		Task<SkillCategory?> GetByName(string CategoryName);
	}
}
