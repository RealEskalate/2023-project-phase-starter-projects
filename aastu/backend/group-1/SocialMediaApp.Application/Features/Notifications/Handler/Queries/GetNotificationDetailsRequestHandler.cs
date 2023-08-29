using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Handler.Queries;

public class GetNotificationDetailsRequestHandler : IRequestHandler<GetNotificationDetailsRequest, NotificationDto>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    public GetNotificationDetailsRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    public async Task<NotificationDto> Handle(GetNotificationDetailsRequest request, CancellationToken cancellationToken)
    {
        var notification = await _notificationRepository.GetNotificationDetails(request.UserId, request.NotificationId);
        return _mapper.Map<NotificationDto>(notification);
    }
}
