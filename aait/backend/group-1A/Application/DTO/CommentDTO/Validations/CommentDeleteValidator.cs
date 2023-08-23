using Application.DTOs.CommentDTO;
using FluentValidation;

namespace Application.DTOs.CommentDTO.Validations
{
    public class DeleteCommentValidator : AbstractValidator<CommentDTO>
    {
        public DeleteCommentValidator()
        {
            RuleFor(dto => dto.Id)
    .NotEmpty().WithMessage("Comment Id is required.")
    .GreaterThan(0).WithMessage("Comment Id must be greater than 0.");

        }
    }
}
