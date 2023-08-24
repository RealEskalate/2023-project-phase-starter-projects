using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Queries;


namespace SocialSync.Application.Features.Notifications.Handlers.Queries;

public class GetNotificationDetailRequestHandler : IRequestHandler<GetNotificationDetailRequest, NotificationDto>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;

    public GetNotificationDetailRequestHandler(INotificationRepository notificationRepository, IMapper mapper){
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<NotificationDto> Handle(
        GetNotificationDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var notification = await _notificationRepository.GetAsync(request.Id);
        return _mapper.Map<NotificationDto>(notification);
    }
}
