using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Notifications.Validators;
using Application.Features.Notifications.Requests.Commands;
using MediatR;

namespace Application.Features.Notifications.Handlers.Commands;


public class DeleteNotificationRequestHandler : IRequestHandler<DeleteNotificationRequest, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<Unit> Handle(DeleteNotificationRequest request, CancellationToken token)
    {
        var validator = new UpdateNotificationDtoValidator(_unitOfWork.NotificationRepository);
        var validationResult = await validator.ValidateAsync(request.DeleteDto, token);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var notif = await _unitOfWork.NotificationRepository.Get(request.DeleteDto.Id);
        await _unitOfWork.NotificationRepository.Delete(notif);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}