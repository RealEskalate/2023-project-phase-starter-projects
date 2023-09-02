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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteNotificationHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<BaseResponse<string>> Handle(DeleteNotification request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.NotificationRepository.Exists(request.NotificationId);
            if (!exists) {
                throw new NotFoundException("Notification is not found");
                
            }

            var notification = await _unitOfWork.NotificationRepository.GetSingle(request.NotificationId);

            if (notification.UserId != request.UserId){
                throw new BadRequestException("Notification is not found"
                );
            }
            var result = await _unitOfWork.NotificationRepository.Delete(notification);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notification is deleted successfully"
            };
            
        }
    }
}