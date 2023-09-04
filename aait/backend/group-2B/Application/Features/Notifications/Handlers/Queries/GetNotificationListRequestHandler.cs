using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Queries;


namespace SocialSync.Application.Features.Notifications.Handlers.Queries;

public class GetNotificationListRequestHandler : IRequestHandler<GetNotificationListRequest, CommonResponse<List<NotificationListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetNotificationListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<NotificationListDto>>> Handle(
        GetNotificationListRequest request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.UserRepository.GetAsync(request.UserId);
        if (user == null){
            return CommonResponse<List<NotificationListDto>>.Failure("User Doesn't Exist");
        }

        var notifications = await _unitOfWork.NotificationRepository.GetAll(request.UserId);
        // Handle null case
        if(notifications == null)
        {
            CommonResponse<List<NotificationListDto>>.Failure("Notifications Not Found");
        }

        return CommonResponse<List<NotificationListDto>>.Success(_mapper.Map<List<NotificationListDto>>(notifications));

    }
}
