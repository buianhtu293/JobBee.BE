using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Application.PayOSService;
using JobBee.Domain.Entities;
using MediatR;
using Net.payOS;
using Net.payOS.Types;

namespace JobBee.Application.Features.Payment.Command.HandlePayment
{
	public class PaymentHandler(
		IUnitOfWork<Domain.Entities.Payment, Guid> paymentRepo,
		IUnitOfWork<Domain.Entities.Subscription, Guid> subcriptionRepo,
		IPayOSService payOSService
	)
		: IRequestHandler<HandlePaymentHook, ApiResponse<bool>>
	{

		public async Task<ApiResponse<bool>> Handle(HandlePaymentHook request, CancellationToken cancellationToken)
		{
			WebhookData webhookData = payOSService.VerifyWebhookSignature(request.webhookBody);
			var payment = await paymentRepo.GenericRepository.FirstOrDefaultAsync(x => x.TransactionId == webhookData.orderCode.ToString());

			if (payment == null)
			{
				throw new NotFoundException(nameof(Payment), request);
			}

			var subcription = await subcriptionRepo.GenericRepository.FirstOrDefaultAsync(x => x.Id == payment.SubscriptionId);

			if (subcription == null)
			{
				throw new NotFoundException(nameof(Subscription), payment);
			}
			var isPaymentSuccess = true;
			if (webhookData.code == "00")
			{
				isPaymentSuccess = true;
				payment.PaymentDate = DateTime.ParseExact(webhookData.transactionDateTime,
				"yyyy-MM-dd HH:mm:ss", null);
				HandlePaymentSuccess(payment, subcription);
			}
			else
			{
				isPaymentSuccess = false;
				payment.PaymentDate = DateTime.ParseExact(webhookData.transactionDateTime,
				"yyyy-MM-dd HH:mm:ss", null);
				HandlePaymentFail(payment, subcription);
			}

			await paymentRepo.SaveChangesAsync();
			return new ApiResponse<bool>("succeess", 200, isPaymentSuccess);
		}

		private void HandlePaymentSuccess(Domain.Entities.Payment payment, Domain.Entities.Subscription subscription)
		{
			payment.Status = "completed";
			subscription.Status = "active";
			subscription.StartDate = DateTime.Now;
			subscription.RenewalDate = CalculateNextRenewalDate(subscription.StartDate, "monthly");
			subscription.EndDate = subscription.RenewalDate;
			subscription.AutoRenew = false;
			subscription.UpdatedAt = DateTime.Now;
		}

		private void HandlePaymentFail(Domain.Entities.Payment payment, Domain.Entities.Subscription subscription)
		{
			payment.Status = "fail";
			subscription.Status = "payment_failed";
			subscription.StartDate = DateTime.Now;
			subscription.UpdatedAt = DateTime.Now;
		}

		private DateTime CalculateNextRenewalDate(DateTime startDate, string billingCycle)
		{
			return billingCycle.ToLowerInvariant() switch
			{
				"monthly" => startDate.AddMonths(1),
				"quarterly" => startDate.AddMonths(3),
				"yearly" => startDate.AddYears(1),
				_ => throw new ArgumentException($"Invalid billing cycle: {billingCycle}")
			};
		}
	}
}
