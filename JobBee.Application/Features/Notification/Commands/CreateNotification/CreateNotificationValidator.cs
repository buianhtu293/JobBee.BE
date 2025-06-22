using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Notification.Commands.CreateNotification
{
	public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
	{
		private readonly INotificationRepository _notificationRepository;

		public CreateNotificationValidator(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}
	}
}
