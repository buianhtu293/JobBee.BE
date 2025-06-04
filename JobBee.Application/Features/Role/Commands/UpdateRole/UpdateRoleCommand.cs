using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Commands.UpdateRole
{
	public class UpdateRoleCommand : IRequest<ApiResponse<UpdateRoleDto>>
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
	}
}
