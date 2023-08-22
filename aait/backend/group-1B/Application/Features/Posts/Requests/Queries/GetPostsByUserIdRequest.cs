using Application.DTOs.Posts;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetPostsByUserIdRequest : IRequest<List<PostContentDto>>
{
    public int UserId { get; set; }
}