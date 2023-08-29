using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Handler.Queries;

public class GetNotificationsRequestHandler : IRequestHandler<GetNotificationsRequest, List<NotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    public GetNotificationsRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    public async Task<List<NotificationDto>> Handle(GetNotificationsRequest request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationRepository.GetNotifications(request.UserId);

            
        return _mapper.Map<List<NotificationDto>>(notifications);
    }
}
