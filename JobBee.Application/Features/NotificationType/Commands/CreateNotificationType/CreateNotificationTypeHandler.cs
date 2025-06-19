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

namespace JobBee.Application.Features.NotificationType.Commands.CreateNotificationType
{
	public class CreateNotificationTypeHandler : IRequestHandler<CreateNotificationTypeCommand, ApiResponse<CreateNotificationTypeDto>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationTypeRepository _notificationTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.NotificationType, Guid> _unitOfWork;

		public CreateNotificationTypeHandler(IMapper mapper, 
			INotificationTypeRepository notificationTypeRepository, 
			IUnitOfWork<Domain.Entities.NotificationType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_notificationTypeRepository = notificationTypeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateNotificationTypeDto>> Handle(CreateNotificationTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateNotificationTypeValidator(_notificationTypeRepository);
			var validatorResult =  await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Notification Type", validatorResult);
			}

			var notificationTypeToCreate = _mapper.Map<Domain.Entities.NotificationType>(request);
			notificationTypeToCreate.Id = Guid.NewGuid();
			notificationTypeToCreate.CreatedAt = DateTime.Now;

			_notificationTypeRepository.Insert(notificationTypeToCreate);

			var notificationTypeCreated = _mapper.Map<CreateNotificationTypeDto>(notificationTypeToCreate);
			var data = new ApiResponse<CreateNotificationTypeDto>("Success", 200, notificationTypeCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
