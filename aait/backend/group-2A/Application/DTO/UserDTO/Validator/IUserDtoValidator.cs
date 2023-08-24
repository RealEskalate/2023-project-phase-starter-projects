using Application.Contracts.Persistance;
using Application.DTO.Post;

namespace Application.DTO.UserDTO.Validator;

using Application.Contracts.Persistance;
using FluentValidation;

public class IUserDtoValidator : AbstractValidator<IUserDTO>{

    public IUserDtoValidator(IUserRepository userRepository){
        RuleFor(user => user.FullName)
            .NotEmpty()
            .WithMessage("Text Is Required")
            .MinimumLength(1)
            .WithMessage("Content Must Be at least 1");
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Invalid Email");
        RuleFor(user => user.UserName)
            .NotEmpty()
            .WithMessage("Username Is Required")
            .Matches(@"^[a-zA-Z0-9_]+$")
            .WithMessage("Invalid Username Format");
    }
    
}


