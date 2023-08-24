using FluentValidation;

namespace Application.DTOs.Posts.Validators;

public class BasePostDtoValidator : AbstractValidator<IPostDto>
{
    public BasePostDtoValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");
        
        RuleFor(dto => dto.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters");
    }
}