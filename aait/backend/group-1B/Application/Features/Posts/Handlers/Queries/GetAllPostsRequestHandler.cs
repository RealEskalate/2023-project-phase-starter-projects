using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetAllPostsRequestHandler : IRequestHandler<GetAllPostsRequest, List<PostContentDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
     
    public GetAllPostsRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<List<PostContentDto>> Handle(GetAllPostsRequest request, CancellationToken token)
    {
        var posts = await _postRepository.GetAll();

        return _mapper.Map<List<PostContentDto>>(posts);
    }
}