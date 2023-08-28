using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Common;
using Application.Response;
using MediatR;

namespace Application.Features.NotificationFeaure.Requests.Commands
{
    public class MarkReadAllRequest : IRequest<BaseResponse<string>>
    {
        public int UserId { get; set; }
    }
}