using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.NotificationType.Queries.GetAllNotificationType
{
	public class NotificationTypeDto
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
		public string? Template { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
