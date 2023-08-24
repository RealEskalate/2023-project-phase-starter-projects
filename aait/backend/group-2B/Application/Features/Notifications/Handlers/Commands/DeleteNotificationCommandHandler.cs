using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Notifications.Requests.Commands;

namespace SocialSync.Application.Features.Notifications.Handlers.Commands;

public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Unit>
{
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            // add any necessary validation here before deleting the notification
            var notification = await _unitOfWork.NotificationRepository.GetAsync(request.NotificationId);
            await _unitOfWork.NotificationRepository.DeleteAsync(notification);

            return Unit.Value;
        }
}
