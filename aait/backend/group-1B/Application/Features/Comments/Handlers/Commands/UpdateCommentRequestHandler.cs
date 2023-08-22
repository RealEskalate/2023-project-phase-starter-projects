using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Comments.Validators;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands;

public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Comment>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public UpdateCommentRequestHandler(ICommentRepository commentRepository, IPostRepository postRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<Comment> Handle(UpdateCommentRequest request, CancellationToken token)
    {
        var validator = new UpdateCommentDtoValidator(_postRepository, _commentRepository);
        var validationResult = await validator.ValidateAsync(request.Comment, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var commentToUpdate = _mapper.Map<Comment>(request.Comment);
        var comment = await _commentRepository.Update(commentToUpdate);

        return comment;
    }
}