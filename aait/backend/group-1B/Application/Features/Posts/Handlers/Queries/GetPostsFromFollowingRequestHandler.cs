using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostsFromFollowingRequestHandler : IRequestHandler<GetPostsFromFollowingRequest, List<PostContentDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostsFromFollowingRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<List<PostContentDto>> Handle(GetPostsFromFollowingRequest request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetPostsFromFollowing(request.UserId);

        return _mapper.Map<List<PostContentDto>>(posts);
    }
}