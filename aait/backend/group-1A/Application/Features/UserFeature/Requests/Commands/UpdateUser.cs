using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using MediatR;


namespace Application.Features.UserFeature.Requests.Commands
{
   public class UpdateUserCommand : IRequest<UserResponseDTO>
    {
        public int userId { get; set; }
        public UserUpdateDTO UserUpdateData { get; set; }
    }
}
