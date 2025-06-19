using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Commands.DeleteNotificationType
{
	public class DeleteNotificationTypeQuery : IRequestHandler<DeleteNotificationTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly INotificationTypeRepository _notificationTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.NotificationType, Guid> _unitOfWork;

		public DeleteNotificationTypeQuery(IMapper mapper,
			INotificationTypeRepository notificationTypeRepository,
			IUnitOfWork<Domain.Entities.NotificationType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_notificationTypeRepository = notificationTypeRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteNotificationTypeCommand request, CancellationToken cancellationToken)
		{
			var notificationTypeToDelete = _notificationTypeRepository.GetById(request.Id);

			if (notificationTypeToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.NotificationType), request.Id);
			}

			_notificationTypeRepository.Delete(notificationTypeToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
