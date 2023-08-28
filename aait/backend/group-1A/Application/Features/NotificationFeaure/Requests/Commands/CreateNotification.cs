using Application.DTO.NotificationDTO;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Commands
{
    public class CreateNotification : IRequest<bool>
    {
        public NotificationCreateDTO NotificationData { get; set; }
    }
}