using Application.Contracts.Persistance;
using FluentValidation;

namespace Application.DTO.Post.Validation;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    public CreatePostDtoValidator(IPostRepository postRepository, IUserRepository userRepository){
        Include(new IPostDtoValidator(postRepository, userRepository));
        
    }
    
    
}