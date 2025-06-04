using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class RoleRepository : GenericRepository<Role, Guid>, IRoleRepository
	{
		public RoleRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<Role?> GetByName(string RoleName)
		{
			return await _context.roles.FirstOrDefaultAsync(q => q.Name == RoleName);
		}

		public async Task<bool> IsRoleUnique(string RoleName)
		{
			return await _context.roles.AnyAsync(q => q.Name == RoleName) == false;
		}
	}
}
