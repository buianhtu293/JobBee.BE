using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Domain;
using JobBee.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType, Guid>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(JobBeeDatabaseContext context) : base(context)
		{
		}

		public async Task<bool> IsLeaveTypeUnique(string name)
		{
			return await _context.LeaveTypes.AnyAsync(x => x.Name == name) == false;
		}
	}
}
