using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.PostDtos.Validators;


// this class is to be fully implmented after the IUserRepository 
public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    // private IUserRepository _userRepository;
    public CreatePostDtoValidator(/*IUserRepository userRepository, */ IPostRepository postRepository)
    {

        // _userRepository = userRepository;

        RuleFor(p => p.Content)
        .NotNull().WithMessage("Post content cannot be null.")
        .NotEmpty().WithMessage("Post content cannot be empty.")
        .MaximumLength(500).WithMessage("Post content cannot have more than {ComparisionValue} characters.");

        RuleFor(p => p.UserId)
        .NotNull().WithMessage("Post author id cannot be null.")
        // .MustAsync(async (id, token)=>{
        //     var userExists =  await _usersRepository.Exists(id);
        //     return userExists
        // }).WithMessage("Post author id doesnot match with any user id.");
        ;


    }
}