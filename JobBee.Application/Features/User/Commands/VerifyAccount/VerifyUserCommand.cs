using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.VerifyAccount
{
	public class VerifyUserCommand() : IRequest<ApiResponse<VerifyUserDto>>
	{
		public string Token { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
	}
}
