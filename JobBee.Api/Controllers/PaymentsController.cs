using JobBee.Application.Features.Payment.Command.CreatePayment;
using JobBee.Application.Models.PayOS;
using JobBee.Shared.APIRoutes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Net.payOS;
using Net.payOS.Types;
using System.Security.Claims;
using System.Text.Json;

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

		[HttpPost(PaymentRoutes.ACTION.HandleWebhook)]
		public async Task<IActionResult> HandleWebHook([FromBody] WebhookType webhookBody)
		{
			string requestBody;
			using (var reader = new StreamReader(Request.Body))
			{
				requestBody = await reader.ReadToEndAsync();
			}

			// Verify webhook signature
			var signature = Request.Headers["X-Webhook-Signature"].FirstOrDefault();

			// request body
			// signature
			

			return Ok(new { status = "success" });
		}
	}
}
