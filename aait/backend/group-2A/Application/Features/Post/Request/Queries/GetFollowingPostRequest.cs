using Application.DTO.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetFollowingPostRequest : IRequest<BaseCommandResponse<List<PostDto>>>
{
    public required int Id{ get; set; }
}