using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.Common;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Commands
{
    public class MarkAllReadHandler : IRequestHandler<MarkReadAllRequest, BaseResponse<string>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public MarkAllReadHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            
        }
        public async Task<BaseResponse<string>> Handle(MarkReadAllRequest request, CancellationToken cancellationToken)
        {
            var result = await _notificationRepository.MarkAllAsRead(entity => entity.UserId == request.UserId && entity.IsRead == false);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notifications are marked as read successfully"
            };
        }
    }
}