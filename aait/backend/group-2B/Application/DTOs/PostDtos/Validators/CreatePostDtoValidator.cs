using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.PostDtos.Validators;


public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
{
    private readonly IUserRepository _userRepository;
    public CreatePostDtoValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(p => p.Content)
        .NotNull().WithMessage("Post content cannot be null.")
        .NotEmpty().WithMessage("Post content cannot be empty.")
        .MaximumLength(500).WithMessage("Post content cannot have more than 500 characters.");

        RuleFor(p => p.UserId)
        .NotNull().WithMessage("Post author id cannot be null.")
        .MustAsync(async (id, token)=>{
            var user =  await _userRepository.GetAsync(id);
            return user != null;
        }).WithMessage("Post author id doesnot match with any user id.");
    }
}