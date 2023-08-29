using Application.DTO.Common;
using Application.Response;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Commands
{
    public class MarkAsReadCommand : IRequest<BaseResponse<string>>
    {
        public int UserId { get; set; }
        public int NotificationId { get; set; }
    }
}