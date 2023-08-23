using AutoMapper;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Features.Posts.Handlers;

public class PostsRequestHandler{
    protected IPostRepository _postRepository;
    protected IMapper _mapper;

    public PostsRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
}