using JobBee.Application.Features.User.Commands.Login;
using JobBee.Shared.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
    public class UsersController : Controller
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
        {
			this._mediator = mediator;
		}

        public async Task<IActionResult> LoginMember([FromBody] LoginRequest loginRequest,
			CancellationToken cancellationToken)
		{
			var command = new LoginCommand(loginRequest.email, loginRequest.password);

			Result<string> tokenResult = await _mediator.Send(command, cancellationToken);

			return Ok(tokenResult.Value);
		}
	}
}
