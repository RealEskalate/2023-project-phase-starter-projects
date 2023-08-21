using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.Post.Validation;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidator(IPostRepository postRepository, IUserRepository userRepository){
        Include(new IPostDtoValidator(postRepository, userRepository));
        RuleFor(post => post.Id)
            .MustAsync(async (id, cancellation) => {
                var exist = await postRepository.Exists(id);
                return exist;
            })
            .WithMessage("Post not found");
        RuleFor(post => post)
            .MustAsync(async (updatedPost, cancellation) =>
            {
                var post = await postRepository.Get(updatedPost.Id);
                return post.UserId == updatedPost.UserId;
            })
            .WithMessage("You are not allowed to do this operation");
    }
    
}