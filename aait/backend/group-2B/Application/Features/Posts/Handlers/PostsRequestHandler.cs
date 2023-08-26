using AutoMapper;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.Features.Posts.Handlers;

public class PostsRequestHandler{
    protected IPostRepository _postRepository;
    protected IUserRepository _userRepository;

    protected IUnitOfWork _unitOfWork;
    protected IMapper _mapper;

    public PostsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _postRepository = _unitOfWork.PostRepository;
        _userRepository = _unitOfWork.UserRepository;
        _mapper = mapper;
    }
}