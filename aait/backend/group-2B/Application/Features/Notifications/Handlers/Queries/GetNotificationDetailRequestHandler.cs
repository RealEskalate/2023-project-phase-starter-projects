using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Queries;


namespace SocialSync.Application.Features.Notifications.Handlers.Queries;

public class GetNotificationDetailRequestHandler : IRequestHandler<GetNotificationDetailRequest, NotificationDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NotificationDto> Handle(
        GetNotificationDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var notification = await _unitOfWork.NotificationRepository.GetAsync(request.Id);
        return _mapper.Map<NotificationDto>(notification);
    }
}
