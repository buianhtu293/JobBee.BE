using JobBee.Api.Models;
using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ISkillCategoryRepository : IGenericRepository<SkillCategory, Guid>
	{
	}
}
