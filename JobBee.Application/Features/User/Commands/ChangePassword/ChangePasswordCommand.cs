using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ChangePassword
{
	public class ChangePasswordCommand : IRequest<ApiResponse<ChangePasswordDto>>
	{
		public string Email { get; set; } = string.Empty;
		public string OldPassword { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string ConfirmPassword { get; set; } = string.Empty;
	}
}
