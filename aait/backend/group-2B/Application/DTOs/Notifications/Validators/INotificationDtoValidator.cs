using FluentValidation;

namespace SocialSync.Application.DTOs.Notifications.Validators
{
    public class INotificationDtoValidator : AbstractValidator<INotificationDto>
    {
        public INotificationDtoValidator()
        {
            RuleFor(n => n.SenderId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            
            RuleFor(n => n.RecepientId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            
            RuleFor(n => n.NotificationType)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} should not be empty.");
        }
    }
}
