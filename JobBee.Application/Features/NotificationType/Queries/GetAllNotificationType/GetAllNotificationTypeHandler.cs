using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.NotificationType.Queries.GetAllNotificationType
{
	public class GetAllNotificationTypeHandler : IRequestHandler<GetAllNotificationTypeQuery, ApiResponse<List<NotificationTypeDto>>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationTypeRepository _notificationTypeRepository;

		public GetAllNotificationTypeHandler(IMapper mapper, 
			INotificationTypeRepository notificationTypeRepository)
		{
			_mapper = mapper;
			_notificationTypeRepository = notificationTypeRepository;
		}

		public async Task<ApiResponse<List<NotificationTypeDto>>> Handle(GetAllNotificationTypeQuery request, CancellationToken cancellationToken)
		{
			var notificationTypes = await _notificationTypeRepository.GetAllListAsync();

			var notificationTypeList = _mapper.Map<List<NotificationTypeDto>>(notificationTypes);
			var data = new ApiResponse<List<NotificationTypeDto>>("Success", 200, notificationTypeList);

			return data;
		}
	}
}
