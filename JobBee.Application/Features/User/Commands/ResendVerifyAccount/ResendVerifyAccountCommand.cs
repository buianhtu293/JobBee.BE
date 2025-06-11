using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.ResendVerifyAccount
{
	public class ResendVerifyAccountCommand : IRequest<ApiResponse<ResendVerifyAccountDto>>
	{
		public string Email { get; set; } = string.Empty;
	}
}
