using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	//public class GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>
	//{
	//}

	public record GetLeaveTypeQuery : IRequest<ApiResponse<List<LeaveTypeDto>>>;
}
