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
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(JobBeeDatabaseContext context) : base(context)
		{
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
		{
			var leaveRequests = await _context.LeaveRequests
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
		{
			var leaveRequests = await _context.LeaveRequests
				.Where(q => q.RequestingEmployeeId == userId)
				.Include(q => q.LeaveType)
				.ToListAsync();
			return leaveRequests;
		}

		public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
		{
			var leaveRequest = await _context.LeaveRequests
				.Include(q => q.LeaveType)
				.FirstOrDefaultAsync(q => q.Id == id);
			return leaveRequest;
		}
	}
}
