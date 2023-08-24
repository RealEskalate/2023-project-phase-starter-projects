using FluentValidation;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;
public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentInteractionDTO>
{
    public UpdateCommentDtoValidator()
    {
        RuleFor(comment => comment.Body)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(200)
            .WithMessage("{proprtyName} can not exceed 200 characters");
    }
}