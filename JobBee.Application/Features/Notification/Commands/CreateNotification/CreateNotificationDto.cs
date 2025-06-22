using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Notification.Commands.CreateNotification
{
	public class CreateNotificationDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid NotificationTypeId { get; set; }
		public string Title { get; set; } = null!;
		public string Message { get; set; } = null!;
		public bool? IsRead { get; set; }
		public string? RelatedEntityType { get; set; }
		public Guid? RelatedEntityId { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
