using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Queries.GetNotificationTypeDetail
{
	public record GetNotificationTypeDetailQuery(Guid id) : IRequest<ApiResponse<NotificationTypeDetailDto>>;
}
