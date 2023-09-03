using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;
namespace Application.Features.User.Request;

public class SearchUsers : IRequest<BaseCommandResponse<List<UserDto>>>{
    public string Query{ get; set; }
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;

}