using Application.Common;
using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using MediatR;


namespace Application.Features.UserFeature.Requests.Commands
{
    public class CreateUserCommand : IRequest<CommonResponseDTO>
    {
        public UserCreateDTO? NewUserData { get; set; }
    }
}
