using JobBee.Application.Features.Payment.Command.CreatePayment;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobBee.Api.Controllers
{
	[Route(PaymentRoutes.Index)]
	[ApiController]
	public class PaymentsController(
		IMediator mediator
	)
		: ControllerBase
	{
		[HttpPost(PaymentRoutes.ACTION.CreatePayment)]
		[Authorize]
		public async Task<IActionResult> CreatePayment(CreatePaymentCommand request)
		{
			var claims = User.Claims;
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
			request.UserId = Guid.Parse(userId!);

			var respose = await mediator.Send(request);

			return Ok(respose);
		}
	}
}
