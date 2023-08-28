using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using FluentValidation;


namespace Application.DTO.UserDTO.validations
{
    public class UserCreateValidation : AbstractValidator<UserCreateDTO>
    {
        IUserRepository _userRepository;
        public UserCreateValidation(IUserRepository userRepository)
        {
             _userRepository = userRepository;

            Include(new CommonUserValidation());
            RuleFor(x => x.Username).MustAsync(async (userName, cancellation) =>
            {
                var allUsers = await _userRepository.GetAllUsers();
                foreach (var user in allUsers)
                {
                    if(user.Username ==  userName)
                    {
                        return false;
                    }
                }

                return true;
            }).WithMessage("A User with this UserName already exists");
            
        }
    }
}
