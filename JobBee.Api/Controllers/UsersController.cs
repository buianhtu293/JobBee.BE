using JobBee.Application.Features.User.Commands.Login;
using JobBee.Application.Features.User.Commands.Register;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Models.Response;
using JobBee.Shared.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
        {
			this._mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> LoginMember([FromBody] LoginRequest loginRequest,
			CancellationToken cancellationToken)
		{
			var command = new LoginCommand(loginRequest.email, loginRequest.password);

			Result<string> tokenResult = await _mediator.Send(command, cancellationToken);

			return Ok(tokenResult.Value);
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
		{
			var command = await _mediator.Send(registerUserCommand);
			return Ok(command);
		}

		[HttpGet]
		public async Task<ActionResult> GetUsers([FromQuery] GetAllUserQuery getAllUserQuery)
		{
			var result = await _mediator.Send(getAllUserQuery);
			return Ok(result);
		}
	}
}
