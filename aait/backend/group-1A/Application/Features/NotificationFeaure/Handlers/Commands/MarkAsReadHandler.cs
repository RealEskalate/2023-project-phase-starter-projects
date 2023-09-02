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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MarkAsReadHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseResponse<string>> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.NotificationRepository.Exists(request.NotificationId);
            if(!exists) {
                throw new NotFoundException("Notification is not found");
            }
            var result = await _unitOfWork.NotificationRepository.MarkAsRead(request.NotificationId, request.UserId);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notification is marked as read successfully"
            };
        }
    }
}