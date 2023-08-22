using FluentValidation;

namespace Application.DTO.CommentDTO.Validator;

public class ICommentDtoValidator : AbstractValidator<ICommentDto>
{
    public ICommentDtoValidator()
    {
        RuleFor(c => c.Content)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(300)
            .WithMessage("{PropertyName} must not exceed 300 characters.")
            .MinimumLength(2)
            .WithMessage("{PropertyName} must be at least 2 characters.");
        
    }
}