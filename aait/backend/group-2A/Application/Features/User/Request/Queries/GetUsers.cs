using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUsers : IRequest<BaseCommandResponse<List<UserDto>>>{
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;

}