using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.DTOs.PostLikes.Validators;

public class ChangeLikeDtoValidator : AbstractValidator<ChangeLikeDto>
{
    public ChangeLikeDtoValidator(IPostRepository postRepository)
    {
        RuleFor(dto => dto.PostId)
            .MustAsync(async (postId, token) =>
            {
                var exists = await postRepository.Exists(postId);
                return exists;
            });
    }
}