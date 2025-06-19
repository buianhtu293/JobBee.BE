using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.Notification.Commands.CreateNotification;
using JobBee.Application.Features.Notification.Queries.GetNotificationByUser;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class NotificationProfile : Profile
	{
        public NotificationProfile()
        {
            CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();

            CreateMap<Notification, NotificationDto>()
				.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
				.ForMember(dest => dest.NotificationType, opt => opt.MapFrom(src => src.NotificationType.TypeName));
		}
    }
}
