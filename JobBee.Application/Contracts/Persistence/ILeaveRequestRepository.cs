using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
	{
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
	}
}
