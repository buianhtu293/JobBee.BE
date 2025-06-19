using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType
{
	public class UpdateNotificationTypeDto
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
		public string? Template { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
