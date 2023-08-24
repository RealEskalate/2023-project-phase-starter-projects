using Application.DTO.UserDTO;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUsers : IRequest<List<UserDto>>{

}