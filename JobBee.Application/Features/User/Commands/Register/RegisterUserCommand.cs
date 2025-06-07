using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Commands.Register
{
	public class RegisterUserCommand : IRequest<ApiResponse<RegisterUserDto>>
	{
		public string? UserName { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? PasswordConfirm { get; set; }
		public bool? IsCandidate { get; set; }
	}
}
