using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;


public class GetAllPostsRequestHandler : PostsRequestHandler, IRequestHandler<GetAllPostsRequest, List<GeneralPostDto>>
{
    public GetAllPostsRequestHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<List<GeneralPostDto>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<GeneralPostDto>>(await _postRepository.GetAsync());
    }
}