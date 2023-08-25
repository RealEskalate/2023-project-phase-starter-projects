
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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChangeLikeRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeLikeRequest request, CancellationToken token)
    {
        var validator = new ChangeLikeDtoValidator(_unitOfWork.PostRepository);
        var validationResult = await validator.ValidateAsync(request.ChangeLike, token);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var liked = await _unitOfWork.PostLikesRepository.ChangeLike(_mapper.Map<PostLike>(request.ChangeLike));
        if (liked == 1)
        {
            var recievingPost = await _unitOfWork.PostRepository.Get(request.ChangeLike.PostId);

            var notif = new Notification()
            {
                UserId = recievingPost.UserId,
                NotificationType = NotificationType.Like,
                Message = $"User {request.ChangeLike.UserId} has liked your post with Id {request.ChangeLike.PostId}."
            };
        
            await _unitOfWork.NotificationRepository.Add(notif);
        }

        await _unitOfWork.Save();
        return Unit.Value;
    }
    
}