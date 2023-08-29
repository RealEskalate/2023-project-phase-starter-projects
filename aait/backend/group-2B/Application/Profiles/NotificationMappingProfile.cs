using AutoMapper;
using SocialSync.Domain.Entities;
using SocialSync.Application.DTOs.Notifications;

namespace SocialSync.Application.Profiles;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
        {
            
            CreateMap<Notification, NotificationDto>();
            CreateMap<Notification, NotificationListDto>();
            CreateMap<NotificationCreateDto, Notification>();

        }

}
