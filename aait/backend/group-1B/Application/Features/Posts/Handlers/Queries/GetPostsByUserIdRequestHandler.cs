using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostsByUserIdRequestHandler : IRequestHandler<GetPostsByUserIdRequest, List<PostContentDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetPostsByUserIdRequestHandler(IPostRepository postRepository, IUserRepository userRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<PostContentDto>> Handle(GetPostsByUserIdRequest request, CancellationToken token)
    {
        var user = await _userRepository.GetUserDetail(request.UserId);
        if (user == null)
            throw new NotFoundException(nameof(User), request.UserId);

        var posts = await _postRepository.GetByUserId(request.UserId);
        return _mapper.Map<List<PostContentDto>>(posts);
    }
}