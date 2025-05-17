using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ILeaveTypeRepository : IGenericRepository<LeaveType, Guid>
	{
		Task<bool> IsLeaveTypeUnique(string name);
	}
}
