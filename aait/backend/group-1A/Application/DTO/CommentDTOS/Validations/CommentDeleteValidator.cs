
using Application.DTO.CommentDTOS.DTO;
using FluentValidation;

namespace Application.DTOs.CommentDTOS.Validations
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
