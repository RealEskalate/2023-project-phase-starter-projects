using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostByIdRequest : IRequest<PostDto>
{
    public int Id { get; set; }
}