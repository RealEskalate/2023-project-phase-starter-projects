using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByTagsRequestHandler : PostsRequestHandler, IRequestHandler<GetPostsByTagsRequest, List<GeneralPostDto>>
{
    public GetPostsByTagsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<GeneralPostDto>> Handle(GetPostsByTagsRequest request, CancellationToken cancellationToken)
    {
        var postsByTags = await _postRepository.GetPostsByTagsAsync(request.Tags);
        return _mapper.Map<List<GeneralPostDto>>(postsByTags);
    }
}
