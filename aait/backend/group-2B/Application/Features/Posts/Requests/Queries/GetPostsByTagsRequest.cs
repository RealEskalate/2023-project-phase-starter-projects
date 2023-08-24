using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByTagsRequest : IRequest<IReadOnlyCollection<GeneralPostDto>>
{

    public List<string> Tags;
    public GetPostsByTagsRequest(List<string> tags)
    {
        Tags = tags;
    }
}