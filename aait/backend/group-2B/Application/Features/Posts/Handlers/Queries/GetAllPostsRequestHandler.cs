using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;


public class GetAllPostsRequestHandler : PostsRequestHandler, IRequestHandler<GetAllPostsRequest, List<PostDto>>
{
    public GetAllPostsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<PostDto>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<PostDto>>(await _postRepository.GetAsync());
    }
}