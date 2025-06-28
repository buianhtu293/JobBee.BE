using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Application.PayOSService;
using MediatR;
using Net.payOS.Types;

namespace JobBee.Application.Features.Payment.Command.CreatePayment
{
	public class CreatePaymentHandler(
		IUnitOfWork<Domain.Entities.Payment, Guid> paymentRepository,
		IUnitOfWork<Domain.Entities.Subscription, Guid> subcriptionRepository,
		IUnitOfWork<Domain.Entities.SubscriptionPlan, Guid> subcriptionPlanRepository,
		IPayOSService payOSService
	) : IRequestHandler<CreatePaymentCommand, ApiResponse<CreatePaymentResult>>
	{
		public async Task<ApiResponse<CreatePaymentResult>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
		{
			// get plan
			var plan = await subcriptionPlanRepository.GenericRepository.FirstOrDefaultAsync(x => x.Id == request.PlanId);
			if (plan == null)
			{
				throw new NotFoundException(nameof(plan), request.PlanId);
			}

			// create subcription with pending status
			var subcription = new Domain.Entities.Subscription
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				PlanId = plan.Id,
				Status = "pending",
				PaymentMethod = "payOS",
				CreatedAt = DateTime.Now,
				UpdatedAt = DateTime.Now,
			};
			subcriptionRepository.GenericRepository.Insert(subcription);

			// create payment with status pending
			var payment = new Domain.Entities.Payment
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				SubscriptionId = subcription.Id,
				Amount = plan.Price,
				Currency = plan.Currency,
				Status = "pending",
				PaymentMethod = "payos",
				Description = $"Thanh toán gói {plan.PlanName}"
			};
			paymentRepository.GenericRepository.Insert(payment);

			var paymentResult = await payOSService.CreatePayTransaction(plan.Id);

			payment.TransactionId = paymentResult.orderCode.ToString();
			await paymentRepository.SaveChangesAsync();

			return new ApiResponse<CreatePaymentResult>("Success", 200, paymentResult);
		}
	}
}
