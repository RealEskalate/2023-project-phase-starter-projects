using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Authentication.Command.DTO;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Authentication.Command.Validations;

public class ValidateCreateUserDto : AbstractValidator<User>
{
    private readonly IUserRepository _userRepository;

    public ValidateCreateUserDto(IUserRepository userRepository)
    {
      _userRepository = userRepository;

        RuleFor(User => User.Name)
        .NotEmpty().WithMessage("{PropertyName} is required")
        .NotNull()
        .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");

       RuleFor(User => User.email)
      .NotEmpty().WithMessage("{PropertyName} is required")
      .EmailAddress().WithMessage("{PropertyName} is invalid")
      .NotNull()
      .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");

       RuleFor(User => User.password)
      .NotEmpty().WithMessage("{PropertyName} is required")
      .MinimumLength(8).WithMessage("{PropertyName} must be 8 characters. ")
      .Matches("[A-z]").WithMessage("Password must contain at least one uppercase letter.")
      .Matches("[a-z]").WithMessage("Password must contain at least one small letter.")
      .Matches("[0-9]").WithMessage("Password must contain at least one number.")
      .Matches("[!@#$%^&*]").WithMessage("Password must contain at least one special character.");
    }


    
}