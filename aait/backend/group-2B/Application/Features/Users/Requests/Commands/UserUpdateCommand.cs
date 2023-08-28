
using Application.DTOs.Common;
using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class UserUpdateCommand : IRequest<Unit>
    {
        public required UserDto Userdto {get;set;}
    }
}