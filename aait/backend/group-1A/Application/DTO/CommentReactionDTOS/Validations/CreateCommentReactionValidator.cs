using FluentValidation;
using Application.DTO.CommentReactionDTOS.DTO;

namespace Application.DTO.CommentReactionDTOS.Validations
{
    public class CreateCommentReactionValidator : AbstractValidator<CommentReactionDTO>
    {
        public CreateCommentReactionValidator()
        {
            RuleFor(dto => dto.CommentId).GreaterThan(0).WithMessage("Comment Id must be greater than 0.");
            RuleFor(dto => dto.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            // Add other validation rules with custom error messages
        }
    }
}
