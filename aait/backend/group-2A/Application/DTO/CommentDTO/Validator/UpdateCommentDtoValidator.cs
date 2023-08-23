using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.CommentDTO.Validator;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
{
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentDtoValidator(ICommentRepository commentRepository)
    {
        Include(new ICommentDtoValidator(  ));
        _commentRepository = commentRepository;
        
        RuleFor(dto => dto.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .MustAsync(async (id, token) => await _commentRepository.Exists(id))
            .WithMessage("Comment does not exist.");

        RuleFor(post => post)
            .MustAsync(async (updatedComment, cancellation) =>
            {
                var comment = await commentRepository.Get(updatedComment.Id);
                return comment.UserId == updatedComment.UserId;
            })
            .WithMessage("You are not allowed to do this operation"); 

        
    }  
}