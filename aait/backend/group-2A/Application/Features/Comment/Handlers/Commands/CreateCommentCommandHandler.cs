using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator(_postRepository, _userRepository);
        var validationResult = await validator.ValidateAsync(request.CommentDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var comment = _mapper.Map<Domain.Entities.Comment>(request.CommentDto);

        await _commentRepository.Add(comment);

        return comment.Id;
    }
}