using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.DTOs.PostDtos.Validators;
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
            var postExists = await _postRepository.ExistsAsync(id);
            return postExists;
        }).WithMessage("Given id did not match any post id.");



        RuleFor(p => p.Content)
        .NotNull().WithMessage("Post content cannot be null.")
        .NotEmpty().WithMessage("Post content cannot be empty.")
        .MaximumLength(500).WithMessage("Post content cannot have more than 500 characters.");


        RuleFor(p => new {p.Id,  p.UserId})
        .NotNull().WithMessage("Post author id cannot be null.")
        .MustAsync(async (dto, token) =>
        {
            var post = await _postRepository.GetAsync(dto.Id);
            if (post == null)
            {
                return false;
            }

            var user = await _userRepository.GetAsync(post.UserId);
            return user != null && user.Id == dto.UserId;
        }).WithMessage("Post author id does not match with the author of the post being updated.");





    }
}