using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType
{
	public class UpdateNotificationTypeValidator : AbstractValidator<UpdateNotificationTypeCommand>
	{
		private readonly INotificationTypeRepository _notificationTypeRepository;

		public UpdateNotificationTypeValidator(INotificationTypeRepository notificationTypeRepository)
		{
			_notificationTypeRepository = notificationTypeRepository;
		}
	}
}
