using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.Notification.Commands.DeleteNotification
{
	public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly INotificationRepository _notificationRepository;
		private readonly IUnitOfWork<Domain.Entities.Notification, Guid> _unitOfWork;

		public DeleteNotificationHandler(IMapper mapper,
			INotificationRepository notificationRepository,
			IUnitOfWork<Domain.Entities.Notification, Guid> unitOfWork)
		{
			_mapper = mapper;
			_notificationRepository = notificationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
		{
			var notificationToDelete = _notificationRepository.GetById(request.Id);

			if (notificationToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Notification), request.Id);
			}

			_notificationRepository.Delete(notificationToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
