using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.Like.Validator;

public class LikedDtoValidator : AbstractValidator<LikedDto>{
    public LikedDtoValidator(IUserRepository userRepository, IPostRepository postRepository){

        RuleFor(like => like.UserId)
            .MustAsync(async (Id, cancellation) => {
                var existingUser = await userRepository.Get(Id);
                return existingUser != null;
            })
            .WithMessage("User Does not exist");
            RuleFor(like => like.PostId)
            .MustAsync(async (Id, cancellation) => {
                var existingPost = await postRepository.Get(Id);
                return existingPost != null;
            })
            .WithMessage("Post Does not exist");
    }

}