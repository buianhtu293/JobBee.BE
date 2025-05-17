﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int DefaultDays { get; set; }
	}
}
