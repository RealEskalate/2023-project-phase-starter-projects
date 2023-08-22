
using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.PostLikes.Validators;
using Application.Features.PostLikes.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostLikes.Handlers.Commands;

public class ChangeLikeRequestHandler : IRequestHandler<ChangeLikeRequest, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly IPostLikesRepository _likesRepository;
    private readonly IMapper _mapper;

    public ChangeLikeRequestHandler(IPostLikesRepository postLikesRepository, IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _likesRepository = postLikesRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeLikeRequest request, CancellationToken token)
    {
        var validator = new ChangeLikeDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.ChangeLike, token);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        await _likesRepository.ChangeLike(_mapper.Map<PostLike>(request.ChangeLike));
        return Unit.Value;
    }
    
}