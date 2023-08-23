using AutoMapper;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Features.Posts.Handlers;

public class PostsRequestHandler{
    protected IPostRepository _postRepository;
    protected IMapper _mapper;

    public PostsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _postRepository = unitOfWork.PostRepository;
        _mapper = mapper;
    }
}