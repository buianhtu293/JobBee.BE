using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType
{
	public class UpdateNotificationTypeCommand : IRequest<ApiResponse<UpdateNotificationTypeDto>>
	{
		public Guid Id { get; set; }
		public string TypeName { get; set; } = null!;
		public string? Template { get; set; }
	}
}
