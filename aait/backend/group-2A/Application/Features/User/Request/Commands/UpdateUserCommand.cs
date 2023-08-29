using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Commands;

public class UpdateUserCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required UpdateUserDTO updateUser { get; set; }
}