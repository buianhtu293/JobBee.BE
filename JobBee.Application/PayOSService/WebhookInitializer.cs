using JobBee.Application.Models.PayOS;
using Microsoft.Extensions.Options;
using Net.payOS;

namespace JobBee.Application.PayOSService
{
	public class WebhookInitializer
	{
		private readonly PayOS _payOS;
		private readonly ReturnSettings _returnSettings;

		public WebhookInitializer(PayOS payOS, IOptions<ReturnSettings> returnOptions)
		{
			_payOS = payOS;
			_returnSettings = returnOptions.Value;
		}

		public async Task RegisterWebhookAsync()
		{
			await _payOS.confirmWebhook(_returnSettings.WebhookUrl);
		}
	}

}
