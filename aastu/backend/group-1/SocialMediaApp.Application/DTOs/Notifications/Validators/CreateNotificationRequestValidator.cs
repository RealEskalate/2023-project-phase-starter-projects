using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Notifications.Validators
{
    internal class CreateNotificationRequestValidator : AbstractValidator<CreateNotificationDto>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserRepository _userRepository;
        public CreateNotificationRequestValidator(INotificationRepository notificationRepository, IUserRepository userRepository) {
            _notificationRepository = notificationRepository;
            _userRepository = userRepository;
            Include( new INotificationDtoValidator(_notificationRepository, _userRepository) );
            RuleFor(n => n.IsRead)
                .Equal(false)
                .WithMessage("{PropertyName} must be false");
        }
    }
}
