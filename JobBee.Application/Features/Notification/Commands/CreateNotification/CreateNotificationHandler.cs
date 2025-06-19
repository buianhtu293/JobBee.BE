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

namespace JobBee.Application.Features.Notification.Commands.CreateNotification
{
	public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, ApiResponse<CreateNotificationDto>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationRepository _notificationRepository;
		private readonly IUnitOfWork<Domain.Entities.Notification, Guid> _unitOfWork;

		public CreateNotificationHandler(IMapper mapper, 
			INotificationRepository notificationRepository, 
			IUnitOfWork<Domain.Entities.Notification, Guid> unitOfWork)
		{
			_mapper = mapper;
			_notificationRepository = notificationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateNotificationDto>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateNotificationValidator(_notificationRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Notification", validatorResult);
			}

			var notificationToCreate = _mapper.Map<Domain.Entities.Notification>(request);
			notificationToCreate.Id = Guid.NewGuid();
			notificationToCreate.CreatedAt = DateTime.Now;

			_notificationRepository.Insert(notificationToCreate);

			var notificationCreated = _mapper.Map<CreateNotificationDto>(notificationToCreate);
			var data = new ApiResponse<CreateNotificationDto>("Success", 200, notificationCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
