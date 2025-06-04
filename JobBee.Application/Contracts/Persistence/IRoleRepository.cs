using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IRoleRepository : IGenericRepository<Role, Guid>
	{
		Task<bool> IsRoleUnique(string RoleName);
		Task<Role?> GetByName(string RoleName);
	}
}
