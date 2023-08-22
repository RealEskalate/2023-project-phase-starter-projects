using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.Post.Validation;

public class IPostDtoValidator : AbstractValidator<IPostDto>{
    public IPostDtoValidator(IPostRepository postRepository, IUserRepository userRepository){
        RuleFor(post => post.Content)
            .NotEmpty()
            .WithMessage("Text Is Required")
            .MinimumLength(1)
            .WithMessage("Content Must Be at least 1");
        RuleFor(post => post.UserId)
            .MustAsync(async (id, cancellation) =>
            {
                var exist = await userRepository.Exists(id);
                return  exist;
            }).WithMessage("User not found");
        
    }
    
}