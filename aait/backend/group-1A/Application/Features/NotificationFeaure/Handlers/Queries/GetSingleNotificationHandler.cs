using Application.Contracts;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Queries
{
    public class GetSingleNotificationHandler : IRequestHandler<GetSingleNotification, BaseResponse<NotificationResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<NotificationResponseDTO>> Handle(GetSingleNotification request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.NotificationRepository.Exists(request.NotificationId);
            if (!exists) {
                throw new NotFoundException("Notification is not found"
                );
            }
            
            var result = await _unitOfWork.NotificationRepository.GetSingle(request.NotificationId);
            return new BaseResponse<NotificationResponseDTO> () {
                Success = true,
                Message = "Notification is retrieved successfully",
                Value = _mapper.Map<NotificationResponseDTO>(result)
            };
        }
    }
}