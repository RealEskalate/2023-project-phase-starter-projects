using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.CommentDTO.Validator;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommentDtoValidator( IPostRepository postRepository, IUserRepository userRepository)
    {
        Include(new ICommentDtoValidator( ));
        
        _postRepository = postRepository;
        _userRepository = userRepository;

        RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("PostId is required")
            .MustAsync(async (id, token) => await _postRepository.Exists(id))
            .WithMessage("Post does not exist");
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required")
            .MustAsync(async (id, token) => await _userRepository.Exists(id))
            .WithMessage("User does not exist");
        
    }
}