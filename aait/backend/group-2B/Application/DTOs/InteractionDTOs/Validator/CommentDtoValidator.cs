using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.Validator;

public class CommentDtoValidator : AbstractValidator<InteractionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public CommentDtoValidator(
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;

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
                    var postExists = await _unitOfWork.PostRepository.GetAsync(id);
                    return postExists != null;
                }
            )
            .WithMessage("{PropertyName} doesn't exist");
        
        RuleFor(interaction => interaction.UserId)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var userExists = await _unitOfWork.UserRepository.GetAsync(id);
                    return userExists != null;
        
                }
            )
            .WithMessage("{PropertyName} doesn't exist");
    }
}