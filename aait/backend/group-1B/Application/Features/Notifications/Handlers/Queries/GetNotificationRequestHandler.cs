using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Notifications;
using Application.Features.Notifications.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Handlers.Queries;

public class GetNotificationRequestHandler : IRequestHandler<GetNotificationRequest, NotificationContentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<NotificationContentDto> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
    {
        var exists = await _unitOfWork.NotificationRepository.Exists(request.Id);
        if (exists == false)
            throw new NotFoundException(nameof(Notification), request.Id);

        var notif = await _unitOfWork.NotificationRepository.Get(request.Id);
        return _mapper.Map<NotificationContentDto>(notif);
    }
}