namespace JobBee.Application.Models.PayOS
{
	public class ReturnSettings
	{
		public string CancelUrl { get; set; } = null!;
		public string ReturnUrl { get; set; } = null!;
		public string WebhookUrl { get; set; } = null!;
	}
}
