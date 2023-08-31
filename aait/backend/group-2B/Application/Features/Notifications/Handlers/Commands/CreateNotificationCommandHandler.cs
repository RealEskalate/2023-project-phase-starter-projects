using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications.Validators;
using SocialSync.Domain.Entities;
using SocialSyncApplication.Features.Notifications.Requests.Commands;


namespace SocialSync.Application.Features.Notifications.Handlers.Commands;

public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CommonResponse<int>>
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNotificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommonResponse<int>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            // add any necessary validation here before creating the notification
            var validator = new NotificationCreateDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.NotificationCreateDto);

            if(!validationResult.IsValid){
                return CommonResponse<int>.FailureWithError("Validation errror", validationResult.Errors);
            }

            var notification = _mapper.Map<Notification>(request.NotificationCreateDto);
            notification = await _unitOfWork.NotificationRepository.AddAsync(notification);

            if( await _unitOfWork.SaveAsync() == 0)
            {
                return CommonResponse<int>.Failure("Error While Saving Changes!");
            
            }

            return CommonResponse<int>.Success(notification.Id);

        }
}
