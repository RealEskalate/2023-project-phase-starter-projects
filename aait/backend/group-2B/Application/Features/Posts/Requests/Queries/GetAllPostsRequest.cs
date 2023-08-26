using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetAllPostsRequest : IRequest<List<GeneralPostDto>>
{
    public GetAllPostsRequest()
    {

    }
}