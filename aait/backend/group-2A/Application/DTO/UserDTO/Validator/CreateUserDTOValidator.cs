using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.UserDTO.Validator;

public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>{

    public CreateUserDTOValidator(IUserRepository userRepository){
        Include(new IUserDtoValidator( userRepository));
        
        RuleFor(user => user.Email)
            .MustAsync(async (email, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByEmail(email);
                return existingUser == null;
            })
            .WithMessage("Email already exists")
            .MustAsync(async (username, cancellation) =>
            {
                var existingUser = await userRepository.GetUserByUserName(username);
                return existingUser == null;
            })
            .WithMessage("Username already exists");
    }
    
}