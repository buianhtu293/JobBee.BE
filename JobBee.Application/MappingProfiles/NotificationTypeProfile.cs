using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.NotificationType.Commands.CreateNotificationType;
using JobBee.Application.Features.NotificationType.Commands.UpdateNotificationType;
using JobBee.Application.Features.NotificationType.Queries.GetAllNotificationType;
using JobBee.Application.Features.NotificationType.Queries.GetNotificationTypeDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class NotificationTypeProfile : Profile
	{
        public NotificationTypeProfile()
        {
            CreateMap<NotificationType, CreateNotificationTypeCommand>().ReverseMap();
            CreateMap<NotificationType, CreateNotificationTypeDto>().ReverseMap();

            CreateMap<NotificationType, UpdateNotificationTypeCommand>().ReverseMap();
            CreateMap<NotificationType, UpdateNotificationTypeDto>().ReverseMap();

            CreateMap<NotificationType, NotificationTypeDto>().ReverseMap();

            CreateMap<NotificationType, NotificationTypeDetailDto>().ReverseMap();
        }
    }
}
