using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.PayOS;
using JobBee.Domain.Entities;
using Microsoft.Extensions.Options;
using Net.payOS;
using Net.payOS.Types;

namespace JobBee.Application.PayOSService
{
	public class PayOSService(
		IUnitOfWork<SubscriptionPlan, Guid> unitOfWork,
		IOptions<ReturnSettings> options,
		PayOS payOS
	) : IPayOSService
	{
		public async Task<CreatePaymentResult> CreatePayTransaction(Guid subcriptionId)
		{
			var subcriptionPlan = unitOfWork.GenericRepository.GetById(subcriptionId);
			if (subcriptionPlan == null)
			{
				throw new NotFoundException(nameof(SubscriptionPlan), subcriptionId);
			}
			List<ItemData> items = new List<ItemData>();
			var price = RoundDecimalToInt(subcriptionPlan.Price);
			items.Add(new ItemData(subcriptionPlan.PlanName, 1, price));
			string cancelUrl = options.Value.CancelUrl;
			string returnUrl = options.Value.ReturnUrl;
			PaymentData paymentData = new PaymentData(GenerateUniquePayOSOrderId(Guid.NewGuid()), price, subcriptionPlan.PlanName, items, cancelUrl, returnUrl);
			CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);
			return createPayment;
		}

		private int RoundDecimalToInt(decimal value)
		{
			return (int)Math.Round(value, MidpointRounding.AwayFromZero);
		}

		private int GenerateUniquePayOSOrderId(Guid guid)
		{
			return Math.Abs(guid.GetHashCode());
		}
	}
}
