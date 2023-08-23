
using Application.DTO.CommentDTOS.DTO;
using FluentValidation;

namespace Application.DTO.CommentDTOS.Validations
{
    public class CreateCommentValidator : AbstractValidator<CommentDTO>
    {
        public CreateCommentValidator()
        {
            RuleFor(dto => dto.Message).NotEmpty().WithMessage("Message is required.");
            RuleFor(dto => dto.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(dto => dto.PostId).GreaterThan(0).WithMessage("PostId must be greater than 0.");
        }
    }
}
