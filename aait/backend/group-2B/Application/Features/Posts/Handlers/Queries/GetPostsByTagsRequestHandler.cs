using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByTagsRequestHandler : PostsRequestHandler, IRequestHandler<GetPostsByTagsRequest, IReadOnlyCollection<GeneralPostDto>>
{
    public GetPostsByTagsRequestHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<IReadOnlyCollection<GeneralPostDto>> Handle(GetPostsByTagsRequest request, CancellationToken cancellationToken)
    {
        var postsByTags = await _postRepository.GetPostsByTags(request.Tags);
        return _mapper.Map<IReadOnlyList<GeneralPostDto>>(postsByTags);
    }
}
