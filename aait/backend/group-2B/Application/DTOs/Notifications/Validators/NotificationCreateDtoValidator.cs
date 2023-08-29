using FluentValidation;
using SocialSync.Application.DTOs.Notifications;

namespace SocialSync.Application.DTOs.Notifications.Validators;

public class NotificationCreateDtoValidator : AbstractValidator<NotificationCreateDto>
{
    public NotificationCreateDtoValidator()
    {
        Include(new INotificationDtoValidator());
    }
}
