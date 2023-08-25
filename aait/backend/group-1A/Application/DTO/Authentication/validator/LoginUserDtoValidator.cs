namespace SocialSync.Application.Dto.Authentication.validator;


using FluentValidation;
using SocialSync.Application.Dtos.Authentication;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>{

    public LoginUserDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }

}