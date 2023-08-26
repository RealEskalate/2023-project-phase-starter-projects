using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.DTOs.PostDtos.Validators;
public class RemovePostDtoValidator : AbstractValidator<RemovePostDto>
{
    private IUserRepository _userRepository;
    private IPostRepository _postRepository;
    public RemovePostDtoValidator(IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _postRepository = postRepository;

        RuleFor(p => p.Id)
        .MustAsync(async (id, token) =>
        {
            var postExists = await _postRepository.ExistsAsync(id);
            return postExists;
        }).WithMessage("Given id did not match any post id.");


        RuleFor(p => new {p.Id, p.UserId})
        .NotNull().WithMessage("Post author id cannot be null.")
        .MustAsync(async (dto, token) =>
        {
            var post = await _postRepository.GetAsync(dto.Id);
            if (post == null)
            {
                return false;
            }

            var user = await _userRepository.GetAsync(dto.UserId);
            return user != null && user.Id == dto.UserId;
        }).WithMessage("Post author id does not match with the author of the post to be removed.");





    }
}