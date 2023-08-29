using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.PostDtos.Validators;
public class DeletePostDtoValidator : AbstractValidator<DeletePostDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    public DeletePostDtoValidator(IUserRepository userRepository, IPostRepository postRepository)
    {
        _userRepository = userRepository;
        _postRepository = postRepository;

        RuleFor(p => p.Id)
        .MustAsync(async (id, token) =>
        {
            bool postExists = await _postRepository.ExistsAsync(id);
            return postExists;
        }).WithMessage("Given id did not match any post id.");

        RuleFor(p => new {p.Id, p.UserId})
        .NotNull().WithMessage("Post author id cannot be null.")
        .MustAsync(async (dto, token) =>
        {
            var post = await _postRepository.GetAsync(dto.Id);
            var user = await _userRepository.GetAsync(dto.UserId);

            return user != null && post != null && post.UserId == user.Id;

        }).WithMessage("Post author id does not match with the id of author of the post being deleted.");
    }
}