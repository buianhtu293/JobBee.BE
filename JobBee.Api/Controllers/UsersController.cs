using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.User.Commands.Login;
using JobBee.Application.Features.User.Commands.Register;
using JobBee.Application.Features.User.Commands.ResendVerifyAccount;
using JobBee.Application.Features.User.Commands.VerifyAccount;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Features.User.Queries.GetUserDetail;
using JobBee.Application.Features.User.Queries.GetUsers;
using JobBee.Application.Models.Response;
using JobBee.Shared.APIRoutes;
using JobBee.Shared.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobBee.Api.Controllers
{
	[Route(UserRoutes.Index)]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork<Domain.Entities.User, Guid> _unitOfWork;

		public UsersController(IMediator mediator,
			IUserRepository userRepository,
			IUnitOfWork<Domain.Entities.User, Guid> unitOfWork)
		{
			this._mediator = mediator;
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
		}

		[HttpDelete]
		[Route(UserRoutes.ACTION.Delete)]
		public void DeleteUser([FromRoute] Guid id)
		{
			_userRepository.Delete(id);
			_unitOfWork.Commit();
		}

		[HttpPost]
		[Route(UserRoutes.ACTION.Login)]
		public async Task<IActionResult> LoginMember([FromBody] LoginRequest loginRequest,
			CancellationToken cancellationToken)
		{
			var command = new LoginCommand(loginRequest.email, loginRequest.password);

			Result<string> tokenResult = await _mediator.Send(command, cancellationToken);

			return Ok(tokenResult.Value);
		}

		[HttpPost]
		[Route(UserRoutes.ACTION.Register)]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
		{
			var command = await _mediator.Send(registerUserCommand);
			return Ok(command);
		}

		[HttpGet(UserRoutes.ACTION.GetListUsers)]
		public async Task<ActionResult> GetUsers()
		{
			var result = await _mediator.Send(new GetUserQuery());
			return Ok(result);
		}

		[HttpGet]
		[Route(UserRoutes.ACTION.GetDetail)]
		public async Task<ActionResult> GetUserDetail([FromRoute]Guid id)
		{
			var user = await _mediator.Send(new GetUserDetailQuery(id));
			return Ok(user);
		}

		[HttpPut]
		[Route(UserRoutes.ACTION.Verify)]
		public async Task<ActionResult> VerifyUser([FromBody] VerifyUserCommand verifyUserCommand)
		{
			var user = await _mediator.Send(verifyUserCommand);
			return Ok(user);
		}

		[HttpPut]
		[Route(UserRoutes.ACTION.Resend)]
		public async Task<ActionResult> ResendVerify([FromBody] ResendVerifyAccountCommand resendVerifyAccountCommand)
		{
			var user = await _mediator.Send(resendVerifyAccountCommand);
			return Ok(user);
		}
	}
}
