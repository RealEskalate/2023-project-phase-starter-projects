using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Domain.Entities;
using SocialSyncApplication.Features.Notifications.Requests.Commands;


namespace SocialSync.Application.Features.Notifications.Handlers.Commands;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
{
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            // add any necessary validation here before creating the notification

            var notification = _mapper.Map<Notification>(request.NotificationCreateDto);
            notification = await _notificationRepository.AddAsync(notification);

            return notification.Id;
        }
}
