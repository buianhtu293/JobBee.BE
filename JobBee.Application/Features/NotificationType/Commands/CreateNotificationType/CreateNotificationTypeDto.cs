using System.ComponentModel.DataAnnotations.Schema;

namespace JobBee.Application.Features.NotificationType.Commands.CreateNotificationType
{
	public class CreateNotificationTypeDto 
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
		public string? Template { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
