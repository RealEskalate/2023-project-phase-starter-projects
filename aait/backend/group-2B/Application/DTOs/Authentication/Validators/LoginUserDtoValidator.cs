using FluentValidation;

namespace SocialSync.Application.DTOs.Authentication.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        Include(new UserDtoValidator());
    }
}
