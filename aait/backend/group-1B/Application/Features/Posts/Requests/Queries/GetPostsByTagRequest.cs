using Application.DTOs.Posts;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetPostsByTagRequest : IRequest<List<PostContentDto>>
{
    public string Tag { get; set; } = string.Empty;
}