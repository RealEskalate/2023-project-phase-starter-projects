using Application.DTO.CommentReactionDTO.DTO;
using Application.DTO.CommentReactionDTOS.DTO;
using FluentValidation;

namespace Application.DTO.CommentReactionDTOS.Validations
{
    public class UpdateCommentReactionValidator : AbstractValidator<CommentReactionUpdateDTO>
    {
        public UpdateCommentReactionValidator()
        {
            RuleFor(dto => dto.Id).GreaterThan(0).WithMessage("Comment Reaction Id must be greater than 0.");
            RuleFor(dto => dto.userId).GreaterThan(0).WithMessage("UserId must be greater than 0.");

        }
    }
}
