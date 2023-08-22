using Application.DTO.PostDTO.DTO;
using FluentValidation;


namespace Application.DTO.PostDTO.validations
{
    public class CommonPostValidation : AbstractValidator<IBasePostDTO>
    {
        public CommonPostValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .NotNull().WithMessage("Title is required")
                .MinimumLength(1).WithMessage("Title must be greater than 1 characters");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required")
                .NotNull().WithMessage("Content is required")
                .MinimumLength(1).WithMessage("Content must be greater than 1 characters");
        }
    }
}
