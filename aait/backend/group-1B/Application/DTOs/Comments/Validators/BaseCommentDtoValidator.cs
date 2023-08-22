using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Comments.Validators;

public class BaseCommentDtoValidator : AbstractValidator<ICommentDto>
{
    public BaseCommentDtoValidator(IPostRepository postRepository)
    {
        RuleFor(dto => dto.Content)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(300).WithMessage("{PropertyName} must not exceed 300 characters");
        
        RuleFor(dto => dto.PostId)
            .MustAsync(async (postId, token) =>
            {
                var exists = await postRepository.Exists(postId);
                return exists;
            });
    }
}