using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Commands.CreateRole
{
	public class CreateRoleCommand : IRequest<ApiResponse<CreateRoleDto>>
	{
		public string? Name { get; set; }
	}
}
