using Application.DTO.UserDTO;
using MediatR;

namespace Application.Features.User.Request.Commands;

public class UpdateUserCommand : IRequest<Unit>
{
    public required UpdateUserDTO updateUser { get; set; }
}