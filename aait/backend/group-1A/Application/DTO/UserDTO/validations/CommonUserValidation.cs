using Application.DTO.UserDTO.DTO;
using FluentValidation;


namespace Application.DTO.UserDTO.validations
{
    public class CommonUserValidation : AbstractValidator<IBaseUserDTO>
    {
        public CommonUserValidation()
        {
             RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .NotNull().WithMessage("Username is required")
            .MinimumLength(1).WithMessage("Username must be at least 1 character long");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .NotNull().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");
        }
    }
}
