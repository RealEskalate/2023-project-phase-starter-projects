using Application.DTO.CommentDTO;
using Application.DTO.Like;
using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

public class GetPostLikesQuery : IRequest<BaseCommandResponse<List<UserDto>>>
{
    public required int Id{ get; set; }
}