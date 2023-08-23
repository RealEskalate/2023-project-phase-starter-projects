using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Notifications;
using Application.DTOs.Notifications.Validators;
using Application.Features.Notifications.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Notifications.Handlers.Commands;

public class CreateNotificationRequestHandler :IRequestHandler<CreateNotificationRequest, GetNotificationDto>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;

    public CreateNotificationRequestHandler(INotificationRepository commentRepository, IMapper mapper)
    {
        INotificationRepository notificationRepository = null;
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<GetNotificationDto> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
    {
        var validator = new GetNotificationDtoValidator(_notificationRepository);
        CancellationToken token = default;
        var validationResult = await validator.ValidateAsync(request.notification, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var notification = await _notificationRepository.Add(_mapper.Map<Notification>(request.notification));

        return _mapper.Map<GetNotificationDto>(notification);
        
    }
}