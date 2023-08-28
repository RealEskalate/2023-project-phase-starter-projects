using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Commands
{
    public class MarkAsReadHandler : IRequestHandler<MarkAsReadCommand, BaseResponse<string>>
    {
         private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public MarkAsReadHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            
        }
        public async Task<BaseResponse<string>> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
        {
            var exists = await _notificationRepository.Exists(request.NotificationId);
            if(!exists) {
                throw new NotFoundException("Notification is not found");
            }
            var result = await _notificationRepository.MarkAsRead(request.NotificationId, request.UserId);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notification is marked as read successfully"
            };
        }
    }
}