using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUsers : IRequest<BaseCommandResponse<List<UserDto>>>{

}