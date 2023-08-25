using FluentValidation;

namespace SocialSync.Application.DTOs.Authentication.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        Include(new UserDtoValidator());

        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(20)
            .WithMessage("{PropertyName} must not exceed 20 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");

        RuleFor(u => u.Bio)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters.")
            .MinimumLength(1)
            .WithMessage("{PropertyName} must be at least 1 characters.");

        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email address.");
    }
}
