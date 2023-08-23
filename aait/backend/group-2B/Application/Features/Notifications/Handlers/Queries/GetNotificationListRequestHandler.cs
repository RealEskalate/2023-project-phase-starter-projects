using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Queries;


namespace SocialSync.Application.Features.Notifications.Handlers.Queries;

public class GetNotificationListRequestHandler : IRequestHandler<GetNotificationListRequest, List<NotificationListDto>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;

    public GetNotificationListRequestHandler(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<List<NotificationListDto>> Handle(
        GetNotificationListRequest request,
        CancellationToken cancellationToken
    )
    {
        var notifications = await _notificationRepository.GetAll(request.UserId);
        return _mapper.Map<List<NotificationListDto>>(notifications);
    }
}
