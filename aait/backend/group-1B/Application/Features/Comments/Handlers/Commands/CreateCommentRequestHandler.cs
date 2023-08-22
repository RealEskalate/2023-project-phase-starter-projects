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
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreateCommentRequestHandler(ICommentRepository commentRepository, IPostRepository postRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<CommentContentDto> Handle(CreateCommentRequest request, CancellationToken token)
    {
        var validator = new CreateCommentDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.Comment, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var comment = await _commentRepository.Add(_mapper.Map<Comment>(request.Comment));

        return _mapper.Map<CommentContentDto>(comment);
    }
}