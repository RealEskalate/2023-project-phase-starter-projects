using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.User.Request.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetSingleNotificationRequestHandler : IRequestHandler<GetSingleNotificationRequest, BaseCommandResponse<Notification>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetSingleNotificationRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }
    

    public async Task<BaseCommandResponse<Notification>> Handle(GetSingleNotificationRequest request, CancellationToken cancellationToken){
        try{
            var notifications = await _unitOfWork.notificationRepository.GetNotification(request.Id);
            if (notifications == null){
                throw new NotFoundException(nameof(Notification), request.Id);
            }
            return BaseCommandResponse<Notification>.SuccessHandler(notifications);
    
        }
        catch(Exception ex){
            return BaseCommandResponse<Notification>.FailureHandler(ex);
        }
        
    }
}

