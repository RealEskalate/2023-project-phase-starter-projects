using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;

namespace AAiT.Backend.G2B.SocialSync.Application.DTOs.Validators.PostDtoValidators;

// this class is to be fully implmented after the IUserRepository 
public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    private IUserRepository _userRepository;
    private IPostRepository _postRepository;
    public UpdatePostDtoValidator(IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;

        _postRepository = postRepository;
        RuleFor(p => p.Id)
        .MustAsync(async (id, token) =>
        {
            var postExists = await _postRepository.Exists(id);
            return postExists;
        }).WithMessage("Given id did not match any post id.");

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