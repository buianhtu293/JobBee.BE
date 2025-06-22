using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Notification.Queries.GetNotificationByUser
{
	public class GetNotificationByUserHandler : IRequestHandler<GetNotificationByUserQuery, ApiResponse<PageResult<NotificationDto>>>
	{
		private readonly IMapper _mapper;
		private readonly INotificationRepository _notificationRepository;

		public GetNotificationByUserHandler(IMapper mapper, INotificationRepository notificationRepository)
		{
			_mapper = mapper;
			_notificationRepository = notificationRepository;
		}

		public async Task<ApiResponse<PageResult<NotificationDto>>> Handle(GetNotificationByUserQuery request, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Notification>, IQueryable<Domain.Entities.Notification>>? filter = null;
			filter = query => query.Where(c => c.IsRead == request.IsRead);

			if (!string.IsNullOrEmpty(request.UserId))
			{
				filter = query => query.Where(c => c.UserId.ToString() == request.UserId);
			}

			Func<IQueryable<Domain.Entities.Notification>, IOrderedQueryable<Domain.Entities.Notification>>? orderBy = null;
			orderBy = query => query.OrderByDescending(c => c.CreatedAt);

			var result = await _notificationRepository.GetPaginatedAsyncIncluding(
				request.PageIndex,
				request.PageSize,
				filter,
				orderBy,
				u => u.User,
				nt => nt.NotificationType
				);

			var dtoItems = _mapper.Map<List<NotificationDto>>(result.Items);

			var notificationList = new PageResult<NotificationDto>(
				dtoItems,
				result.TotalItems,
				result.PageIndex,
				result.PageSize
				);

			return new ApiResponse<PageResult<NotificationDto>>("Success", 200, notificationList);
		}
	}
}
