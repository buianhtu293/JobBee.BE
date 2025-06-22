using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.NotificationType.Commands.CreateNotificationType
{
	public class CreateNotificationTypeValidator : AbstractValidator<CreateNotificationTypeCommand>
	{
		private readonly INotificationTypeRepository _notificationTypeRepository;

		public CreateNotificationTypeValidator(INotificationTypeRepository notificationTypeRepository)
		{
			_notificationTypeRepository = notificationTypeRepository;
		}
	}
}
