using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Notifications.Validators;

public class GetNotificationDtoValidator : AbstractValidator<GetNotificationDto>
{
    public GetNotificationDtoValidator(INotificationRepository notificationRepository)
    {
        throw new NotImplementedException();
    }
}