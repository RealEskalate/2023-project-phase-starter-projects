using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Notifications.Validators;
using Application.Features.Notifications.Requests.Commands;
using MediatR;

namespace Application.Features.Notifications.Handlers.Commands;

public class MarkNotificationAsSeenRequestHandler : IRequestHandler<MarkNotificationAsSeenRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public MarkNotificationAsSeenRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<Unit> Handle(MarkNotificationAsSeenRequest request, CancellationToken token)
    {
        var validator = new UpdateNotificationDtoValidator(_unitOfWork.NotificationRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateDto, token);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        await _unitOfWork.NotificationRepository.MarkAsSeen(request.UpdateDto.Id);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}