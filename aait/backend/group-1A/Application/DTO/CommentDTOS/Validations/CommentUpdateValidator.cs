using Application.DTO.CommentDTOS.DTO;
using FluentValidation;

namespace Application.DTO.CommentDTOS.Validations
{
    public class UpdateCommentValidator : AbstractValidator<CommentDTO>
    {
        public UpdateCommentValidator()
        {
            RuleFor(dto => dto.Id)
    .NotEmpty().WithMessage("Comment Id is required.")
    .GreaterThan(0).WithMessage("Comment Id must be greater than 0.");

            RuleFor(dto => dto.Message).NotEmpty().WithMessage("Message is required.");
        }
    }
}
