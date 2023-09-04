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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MarkAllReadHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<BaseResponse<string>> Handle(MarkReadAllRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.NotificationRepository.MarkAllAsRead(request.UserId);

            return new BaseResponse<string> ()
            {
                Success = true,
                Message = "Notifications are marked as read successfully"
            };
        }
    }
}