using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByUserIdRequestHandler : PostsRequestHandler, IRequestHandler<GetPostsByUserIdRequest, List<PostDto>>
{
    public GetPostsByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<PostDto>> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Post> postsByUserId = await _postRepository.GetPostsByUserIdAsync(request.UserId);
        return _mapper.Map<List<PostDto>>(postsByUserId);
    }
}
