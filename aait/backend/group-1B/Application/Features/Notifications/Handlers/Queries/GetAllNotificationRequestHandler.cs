using Application.Contracts.Persistence;
using Application.DTOs.Notifications;
using Application.Features.Notifications.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Notifications.Handlers.Queries;

public class GetAllNotificationRequestHandler : IRequestHandler<GetAllNotificationsRequest, List<GetNotificationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetAllNotificationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
     
    public async Task<List<GetNotificationDto>> Handle(GetAllNotificationsRequest request, CancellationToken token)
    {
        var comments = await _unitOfWork.NotificationRepository.GetByUserId(request.UserId);
        return _mapper.Map<List<GetNotificationDto>>(comments);
    }
}