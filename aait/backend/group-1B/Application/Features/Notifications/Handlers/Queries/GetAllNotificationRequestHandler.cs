using Application.Contracts.Persistence;
using Application.DTOs.Notifications;
using Application.Features.Notifications.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Notifications.Handlers.Queries;

public class GetAllNotificationRequestHandler : IRequestHandler<GetAllNotifiactionsRequest, List<GetNotificationDto>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;
    
    public GetAllNotificationRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        INotificationRepository notificationRepository = null;
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GetNotificationDto>> Handle(GetAllNotifiactionsRequest request, CancellationToken token)
    {
        var comments = (await _notificationRepository.GetAll()).ToList();
        return _mapper.Map<List<GetNotificationDto>>(comments);
    }
}