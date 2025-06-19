using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Commands.CreateNotificationType
{
	public class CreateNotificationTypeCommand : IRequest<ApiResponse<CreateNotificationTypeDto>>
	{
		public string TypeName { get; set; } = null!;
		public string? Template { get; set; }
	}
}
