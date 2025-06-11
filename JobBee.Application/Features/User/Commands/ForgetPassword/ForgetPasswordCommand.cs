using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ForgetPassword
{
	public class ForgetPasswordCommand : IRequest<ApiResponse<ForgetPasswordDto>>
	{
		public string Email { get; set; } = string.Empty;
	}
}
