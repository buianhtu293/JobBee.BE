using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Notification.Commands.CreateNotification
{
	public class CreateNotificationCommand : IRequest<ApiResponse<CreateNotificationDto>>
	{
		public Guid UserId { get; set; }
		public Guid NotificationTypeId { get; set; }
		public string Title { get; set; } = null!;
		public string Message { get; set; } = null!;
		public bool? IsRead { get; set; }
		public string? RelatedEntityType { get; set; }
		public Guid? RelatedEntityId { get; set; }
	}
}
