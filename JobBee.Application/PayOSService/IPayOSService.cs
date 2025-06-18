using Net.payOS.Types;

namespace JobBee.Application.PayOSService
{
	public interface IPayOSService
	{
		Task<CreatePaymentResult> CreatePayTransaction(Guid subcriptionId);
	}
}
