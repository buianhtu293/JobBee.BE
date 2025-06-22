using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Queries.GetNotificationTypeDetail
{
	public class GetNotificationTypeDetailHandler : IRequestHandler<GetNotificationTypeDetailQuery, ApiResponse<NotificationTypeDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationTypeRepository _notificationTypeRepository;

		public GetNotificationTypeDetailHandler(IMapper mapper,
			INotificationTypeRepository notificationTypeRepository)
		{
			_mapper = mapper;
			_notificationTypeRepository = notificationTypeRepository;
		}

		public async Task<ApiResponse<NotificationTypeDetailDto>> Handle(GetNotificationTypeDetailQuery request, CancellationToken cancellationToken)
		{
			var notificationType = _notificationTypeRepository.GetById(request.id);

			if (notificationType == null)
			{
				throw new NotFoundException(nameof(notificationType), request.id);
			}

			var notificationTypeDetail = _mapper.Map<NotificationTypeDetailDto>(notificationType);
			var data = new ApiResponse<NotificationTypeDetailDto>("Success", 200, notificationTypeDetail);

			return data;
		}
	}
}
