using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.DTOs.Comments.Validators;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands;

public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, CommentContentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommentContentDto> Handle(CreateCommentRequest request, CancellationToken token)
    {
        var validator = new CreateCommentDtoValidator(_unitOfWork.PostRepository);
        var validationResult = await validator.ValidateAsync(request.Comment, token);
        
        Console.WriteLine("Trying to create comment");
        if (validationResult.IsValid == false)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            throw new ValidationException(validationResult);
        }
        
        Console.WriteLine("Here");
        var comment = await _unitOfWork.CommentRepository.Add(_mapper.Map<Comment>(request.Comment));

        var recievingPost = await _unitOfWork.PostRepository.Get(request.Comment.PostId);
        
        var notif = new Notification()
        {
            UserId = recievingPost.UserId,
            NotificationType = NotificationType.Comment,
            Message = $"User {request.Comment.UserId} has commented on your post with Id {request.Comment.PostId}."
        };
        
        await _unitOfWork.NotificationRepository.Add(notif);

        await _unitOfWork.Save();
        return _mapper.Map<CommentContentDto>(comment);
    }
}