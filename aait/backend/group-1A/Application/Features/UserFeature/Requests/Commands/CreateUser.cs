using Application.DTO.UserDTO.DTO;
using Application.Response;
using MediatR;


namespace Application.Features.UserFeature.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseResponse<string>>
    {
        public UserCreateDTO? NewUserData { get; set; }
    }
}
