using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByTagsRequest : IRequest<List<PostDto>>
{

    public List<string> Tags { get; set; } = null!;
}