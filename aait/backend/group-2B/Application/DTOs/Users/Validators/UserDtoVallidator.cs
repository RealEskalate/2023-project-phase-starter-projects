
using FluentValidation;

namespace Application.DTOs.Users.Validators
{
    public class UserDtoVallidator : AbstractValidator<Common.UserDto>
    {
    public UserDtoVallidator()
    {
        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(3, 20).WithMessage("First name length should be between 3 and 20 characters.");

        RuleFor(dto => dto.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(3, 20).WithMessage("Last name length should be between 3 and 20 characters.");

        RuleFor(dto => dto.Bio)
            .Length(1, 100).WithMessage("Bio length should be between 1 and 100 characters.");

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(1, 30).WithMessage("Email length should be between 1 and 30 characters.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(dto => dto.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 20).WithMessage("Username length should be between 3 and 20 characters.");

        RuleFor(dto => dto.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Length(10).WithMessage("Phone number length should be 10 characters.")
            .Matches(@"^\d+$").WithMessage("Phone number should only contain digits.");
    }

        
    }
}