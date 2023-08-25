using FluentValidation;
using SocialSync.Application.Dtos.Authentication;

namespace SocialSync.Application.Dto.Authentication.validator;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>{
    public RegisterUserDtoValidator()
    {

        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.UserName).NotEmpty().MinimumLength(6);
        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(30);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(30);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);

    }
}