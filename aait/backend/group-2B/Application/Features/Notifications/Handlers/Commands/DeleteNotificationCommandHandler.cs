using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Notifications.Requests.Commands;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Notifications.Handlers.Commands;

public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Unit>
{
        private readonly INotificationRepository _notificationRepository;

        public DeleteNotificationCommandHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            // add any necessary validation here before deleting the notification
            Notification notification = await _notificationRepository.GetAsync(request.NotificationId);
            await _notificationRepository.DeleteAsync(notification);

            return Unit.Value;
        }
}
