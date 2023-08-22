using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.Posts.Validators;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidator(IPostRepository postRepository)
    {
        Include(new BasePostDtoValidator());

        RuleFor(dto => dto.Id)
            .MustAsync(async (id, token) =>
            {
                var exists = await postRepository.Exists(id);
                return exists;
            });

        RuleFor(dto => dto)
            .MustAsync(async (dto, token) =>
            {
                var post = await postRepository.Get(dto.Id);
                if (post == null)
                    return false;

                return post.UserId == dto.UserId;
            }).WithMessage("Unauthorized operation. You are not the owner of the post");
    }
}