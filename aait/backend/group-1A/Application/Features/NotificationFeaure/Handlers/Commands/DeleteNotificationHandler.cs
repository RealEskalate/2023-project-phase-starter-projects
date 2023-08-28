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
using Domain.Entites;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Commands
{
    public class DeleteNotificationHandler : IRequestHandler<DeleteNotification, BaseResponse<string>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public DeleteNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            
        }

        public async Task<BaseResponse<string>> Handle(DeleteNotification request, CancellationToken cancellationToken)
        {
            var exists = await _notificationRepository.Exists(request.NotificationId);
            if (!exists) {
                throw new NotFoundException("Notification is not found");
                
            }

            var notification = await _notificationRepository.GetSingle(request.NotificationId);

            if (notification.UserId != request.UserId){
                throw new BadRequestException("Notification is not found"
                );
            }
            var result = await _notificationRepository.Delete(notification);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notification is deleted successfully"
            };
            
        }
    }
}