using Application.DTO.UserDTO.DTO;
using FluentValidation;

namespace Application.DTO.UserDTO.validations
{
    public class UserUpdateValidation : AbstractValidator<UserUpdateDTO> 
    {
        public UserUpdateValidation()
        {
    
        }
    }
}
