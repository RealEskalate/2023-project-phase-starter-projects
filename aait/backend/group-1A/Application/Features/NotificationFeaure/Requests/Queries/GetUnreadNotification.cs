using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.NotificationDTO;
using Application.Response;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Queries
{
    public class GetUnreadNotification : IRequest<BaseResponse<List<NotificationResponseDTO>>>
    {
     public int UserId { get; set; }   
    }
}