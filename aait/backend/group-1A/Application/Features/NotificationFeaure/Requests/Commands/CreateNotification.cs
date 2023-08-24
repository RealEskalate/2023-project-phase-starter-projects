using Application.DTO.NotificationDTO;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Commands
{
    public class CreateNotification : IRequest<bool>
    {
        public int UserId { get; set; }
        public NotificationCreateDTO NotificationData { get; set; }
    }
}