
using FluentValidation;
using SocialSync.Application.DTOs.Authentication;

namespace Application.DTOs.Users.Validators;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(3, 20).WithMessage("{PropertyName} length should be between 3 and 20 characters.");

        RuleFor(dto => dto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(3, 20).WithMessage("{PropertyName} length should be between 3 and 20 characters.");

        RuleFor(dto => dto.Bio)
            .Length(1, 100).WithMessage("{PropertyName} length should be between 1 and 100 characters.");

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(1, 30).WithMessage("{PropertyName} length should be between 1 and 30 characters.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(dto => dto.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.").Length(3, 20).WithMessage("{PropertyName} length should be between 3 and 20 characters.");

        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Length(10).WithMessage("{PropertyName} length should be 10 characters.")
            .Matches(@"^\d+$").WithMessage("{PropertyName} should only contain digits.");
    }


}
