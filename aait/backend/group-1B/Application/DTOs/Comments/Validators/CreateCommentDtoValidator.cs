using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Comments.Validators;

public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
{
    public CreateCommentDtoValidator(IPostRepository postRepository)
    {
        Include(new BaseCommentDtoValidator(postRepository));
    }
}