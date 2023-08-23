using Application.DTO.Like;
using Application.DTO.UserDTO;
using MediatR;

public class GetPostLikesQuery : IRequest<List<UserDto>>
{
    public required int Id{ get; set; }
}