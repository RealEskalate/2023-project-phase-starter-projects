using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetFollowingPostRequest : IRequest<List<PostDto>>
{
    public int Id{ get; set; }
}