using Application.DTO.CommentReactionDTOS.DTO;
using FluentValidation;

namespace Application.DTO.CommentReactionDTOS.Validations
{
    public class UpdateCommentReactionValidator : AbstractValidator<CommentReactionDTO>
    {
        public UpdateCommentReactionValidator()
        {
            RuleFor(dto => dto.Id).GreaterThan(0).WithMessage("Comment Reaction Id must be greater than 0.");
            RuleFor(dto => dto.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            // Add other validation rules with custom error messages
        }
    }
}
