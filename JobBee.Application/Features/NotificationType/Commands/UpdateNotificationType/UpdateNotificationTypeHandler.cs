using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType
{
	public class UpdateNotificationTypeHandler : IRequestHandler<UpdateNotificationTypeCommand, ApiResponse<UpdateNotificationTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationTypeRepository _notificationTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.NotificationType, Guid> _unitOfWork;

		public UpdateNotificationTypeHandler(IMapper mapper,
			INotificationTypeRepository notificationTypeRepository,
			IUnitOfWork<Domain.Entities.NotificationType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_notificationTypeRepository = notificationTypeRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<UpdateNotificationTypeDto>> Handle(UpdateNotificationTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateNotificationTypeValidator(_notificationTypeRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Notification Type", validatorResult);
			}

			var notificationType = _notificationTypeRepository.GetById(request.Id);

			var notificationTypeToUpdate = _mapper.Map<Domain.Entities.NotificationType>(request);
			notificationTypeToUpdate.CreatedAt = notificationType.CreatedAt;

			_notificationTypeRepository.Update(notificationTypeToUpdate);

			var notificationTypeUpdated = _mapper.Map<UpdateNotificationTypeDto>(notificationTypeToUpdate);
			var data = new ApiResponse<UpdateNotificationTypeDto>("Success", 200, notificationTypeUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
