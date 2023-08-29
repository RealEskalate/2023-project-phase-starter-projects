using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostByIdRequest : IRequest<CommonResponse<PostDto>>
{
    public int Id { get; set; }
}