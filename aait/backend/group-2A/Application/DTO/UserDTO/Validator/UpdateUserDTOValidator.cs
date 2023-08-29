using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.UserDTO.Validator;

public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>{

    public UpdateUserDTOValidator(IUserRepository userRepository){
        Include(new IUserDtoValidator( userRepository));

        RuleFor(user => user)
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.Get(us.Id);
                return existingUser != null;
            })
            .WithMessage("User Does not exist")
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.GetUserByEmail(us.Email);
                return existingUser == null || existingUser?.Id == us.Id;
            })
            .WithMessage("Email already exists")
            .MustAsync(async (us, cancellation) => {
                var existingUser = await userRepository.GetUserByUserName(us.UserName);
                return existingUser == null || existingUser?.Id == us.Id;
            })
            .WithMessage("UserName already exists");
    }
    
}