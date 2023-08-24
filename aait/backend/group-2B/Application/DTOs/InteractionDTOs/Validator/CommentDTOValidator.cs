using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.Validator;

public class CommentDTOValidator : AbstractValidator<InteractionDTO>
{
    private IPostRepository _IPostRepository;
    private IUserRepository _IUserRepository;

    public CommentDTOValidator(
        IPostRepository IPostRepository,
        IUserRepository IUserRepository
    )
    {
        _IPostRepository = IPostRepository;

        RuleFor(interaction => interaction.Body)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{propertyName} must be atleast one character")
            .MaximumLength(200)
            .WithMessage("{proprtyName} can not exceed 200 characters");

        RuleFor(interaction => interaction.PostId)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var postExists = await _IPostRepository.GetAsync(id);
                    if (postExists != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            )
            .WithMessage("{PropertyName} doesn't exist");

        RuleFor(interaction => interaction.UserId)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var postExists = await _IUserRepository.GetAsync(id);
                    if (postExists != null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            )
            .WithMessage("{PropertyName} doesn't exist");
    }
}