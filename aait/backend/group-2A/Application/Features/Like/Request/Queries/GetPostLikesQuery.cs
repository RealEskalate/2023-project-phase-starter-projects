using Application.DTO.Like;
using Application.DTO.UserDTO;
using MediatR;

public class GetPostLikesQuery : IRequest<List<LikedDto>>
{
    public required int Id{ get; set; }
}