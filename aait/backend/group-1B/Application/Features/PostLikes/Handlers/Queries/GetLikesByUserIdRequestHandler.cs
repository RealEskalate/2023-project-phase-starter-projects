using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.PostLikes;
using Application.Features.PostLikes.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostLikes.Handlers.Queries;

public class GetLikesByUserIdRequestHandler : IRequestHandler<GetLikesByUserIdRequest, List<PostLikeContentDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPostLikesRepository _likesRepository;
    private readonly IMapper _mapper;

    public GetLikesByUserIdRequestHandler(IPostLikesRepository postLikesRepository, IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _likesRepository = postLikesRepository;
        _mapper = mapper;
    }

    public async Task<List<PostLikeContentDto>> Handle(GetLikesByUserIdRequest request, CancellationToken token)
    {
        var exists = await _userRepository.Exists(request.UserId);
        if (exists == false)
            throw new NotFoundException(nameof(User), request.UserId);

        var likes = await _likesRepository.GetLikesByUserId(request.UserId);
        return _mapper.Map<List<PostLikeContentDto>>(likes);
    }
}