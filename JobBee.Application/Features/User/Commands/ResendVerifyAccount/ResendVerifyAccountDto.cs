using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.User.Commands.ResendVerifyAccount
{
	public class ResendVerifyAccountDto
	{
		public Guid Id { get; set; }
		public string? UserName { get; set; }
		public string? NormalizedUserName { get; set; }
		public string? Email { get; set; }
		public string? NormalizedEmail { get; set; }
		public bool EmailConfirmed { get; set; }
		public string? SecurityStamp { get; set; }
	}
}
