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
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public GetSingleNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<NotificationResponseDTO>> Handle(GetSingleNotification request, CancellationToken cancellationToken)
        {
            var exists = await _notificationRepository.Exists(request.NotificationId);
            if (!exists) {
                throw new NotFoundException("Notification is not found"
                );
            }
            
            var result = await _notificationRepository.GetSingle(request.NotificationId);
            return new BaseResponse<NotificationResponseDTO> () {
                Success = true,
                Message = "Notification is retrieved successfully",
                Value = _mapper.Map<NotificationResponseDTO>(result)
            };
        }
    }
}