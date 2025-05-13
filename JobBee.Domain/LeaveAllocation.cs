using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Common;

namespace JobBee.Domain
{
	public class LeaveAllocation : BaseEntity
	{
		public int NumberOfDays { get; set; }
		public LeaveType LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public int Period { get; set; }
		public string EmployeeId { get; set; } = string.Empty;
	}
}
