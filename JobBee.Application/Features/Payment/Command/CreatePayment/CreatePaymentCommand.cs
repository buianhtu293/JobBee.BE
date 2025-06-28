using JobBee.Application.Models.Response;
using MediatR;
using Net.payOS.Types;
using System.Text.Json.Serialization;

namespace JobBee.Application.Features.Payment.Command.CreatePayment
{
	public class CreatePaymentCommand : IRequest<ApiResponse<CreatePaymentResult>>
	{
		public Guid PlanId { get; set; }

		[JsonIgnore]
		public Guid UserId { get; set; }
	}
}
