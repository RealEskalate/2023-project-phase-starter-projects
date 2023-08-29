using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications.Validators;

public class INotificationDtoValidator :AbstractValidator<INotificationDto>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUserRepository _userRepository;
    public INotificationDtoValidator(INotificationRepository notificationRepository, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _userRepository = userRepository;
        RuleFor(n => n.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        RuleFor(n => n.UserId)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _userRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
        
    }
}
