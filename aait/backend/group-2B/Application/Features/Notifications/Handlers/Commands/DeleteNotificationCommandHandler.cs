using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Notifications.Requests.Commands;

namespace SocialSync.Application.Features.Notifications.Handlers.Commands;

public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, CommonResponse<Unit>>
{
        private readonly IUnitOfWork _unitOfWork;

        public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommonResponse<Unit>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {

            var notification = await _unitOfWork.NotificationRepository.GetAsync(request.NotificationId);
            if(notification == null){
                return CommonResponse<Unit>.Failure("Notification Not Found");
            }
            await _unitOfWork.NotificationRepository.DeleteAsync(notification);

            if( await _unitOfWork.SaveAsync() == 0)
            {
                return CommonResponse<Unit>.Failure("Error While Saving Changes!");
            }

            return CommonResponse<Unit>.Success(Unit.Value);

        }
}
