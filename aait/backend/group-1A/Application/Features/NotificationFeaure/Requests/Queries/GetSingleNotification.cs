using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.NotificationDTO;
using Application.Response;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Queries
{
    public class GetSingleNotification : IRequest<BaseResponse<NotificationResponseDTO>>
    {
        public int NotificationId { get; set; }
    }
}