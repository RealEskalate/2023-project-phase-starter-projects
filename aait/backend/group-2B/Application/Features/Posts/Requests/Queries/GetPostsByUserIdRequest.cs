using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByUserIdRequest : IRequest<List<PostDto>>
{
    public int UserId { get; set; }
}