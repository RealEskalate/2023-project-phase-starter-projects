using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.PostLikes;
using Application.Features.PostLikes.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostLikes.Handlers.Queries;

public class GetLikesByPostIdRequestHandler : IRequestHandler<GetLikesByPostIdRequest, List<PostLikeContentDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IPostLikesRepository _likesRepository;
    private readonly IMapper _mapper;

    public GetLikesByPostIdRequestHandler(IPostLikesRepository postLikesRepository, IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _likesRepository = postLikesRepository;
        _mapper = mapper;
    }

    public async Task<List<PostLikeContentDto>> Handle(GetLikesByPostIdRequest request, CancellationToken token)
    {
        var exists = await _postRepository.Exists(request.PostId);
        if (exists == false)
            throw new NotFoundException(nameof(Post), request.PostId);

        var likes = await _likesRepository.GetLikesByPostId(request.PostId);
        return _mapper.Map<List<PostLikeContentDto>>(likes);
    }
}