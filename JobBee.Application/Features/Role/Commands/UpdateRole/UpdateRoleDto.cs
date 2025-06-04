using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Role.Commands.UpdateRole
{
	public class UpdateRoleDto
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? NormalizedName { get; set; }
		public string? ConcurrencyStamp { get; set; }
	}
}
