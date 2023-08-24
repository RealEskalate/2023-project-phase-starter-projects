using FluentValidation;

namespace Application.DTOs.Posts.Validators;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator()
    {
        Include(new BasePostDtoValidator());
    }
}