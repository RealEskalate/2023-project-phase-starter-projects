using Application.Contracts.Persistance;
using Application.DTOs.Notifications.Validators;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Responses;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands;

public class MakeNotificationReadCommandHandler : IRequestHandler<MakeNotificationReadCommand ,BaseCommandResponse<Unit?>>
{
    private readonly IUnitOfWork _unitOfWork;

    public MakeNotificationReadCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseCommandResponse<Unit?>> Handle(MakeNotificationReadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdateNotificationDtoValidator(_unitOfWork.notificationRepository);
            var validationResult = await validator.ValidateAsync( request.UpdateDto );

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            await _unitOfWork.notificationRepository.MarkAsRead(request.UpdateDto.Id);
            if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something went wrong");
            return BaseCommandResponse<Unit?>.SuccessHandler(Unit.Value);
            
        }
        catch (Exception e)
        {
            return BaseCommandResponse<Unit?>.FailureHandler(e);
        } 
    }
}