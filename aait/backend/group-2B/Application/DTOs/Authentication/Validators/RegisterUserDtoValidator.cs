using FluentValidation;

namespace SocialSync.Application.DTOs.Authentication.Validators;


public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
  public RegisterUserDtoValidator()
  {
  }
}
