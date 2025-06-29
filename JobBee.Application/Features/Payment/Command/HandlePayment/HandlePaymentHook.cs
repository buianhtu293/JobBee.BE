using JobBee.Application.Models.Response;
using MediatR;
using Net.payOS.Types;

namespace JobBee.Application.Features.Payment.Command.HandlePayment
{
	public class HandlePaymentHook : IRequest<ApiResponse<bool>>
	{
		public WebhookType webhookBody { get; set; } = null!;
	}
}
