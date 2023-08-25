using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetFollowingPostRequest : IRequest<List<PostDto>>
{
    public required int Id{ get; set; }
}