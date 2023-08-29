using FluentValidation;

namespace SocialMediaApp.Application.DTOs.Users.Validations
{
    public class IValidateUserDto: AbstractValidator<IUserDto>
    {
        public IValidateUserDto()
        {
          RuleFor(User => User.Name)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .MaximumLength(50).WithMessage("{PropertyName} length should be less than 50 characters");


          RuleFor(User => User.Bio)
          .NotEmpty().WithMessage("{PropertyName} is required")
          .NotNull()
          .MaximumLength(500).WithMessage("{PropertyName} length should be less than 500 characters");
            
        }

    }
}