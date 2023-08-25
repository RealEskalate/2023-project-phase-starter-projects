using FluentValidation;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentInteractionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCommentDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(comment => comment.Body)
            .NotEmpty()
            .WithMessage("{ProprtyName} can not be empty")
            .NotNull()
            .MinimumLength(1)
            .WithMessage("{PropertyName} must be atleast one character")
            .MaximumLength(200)
            .WithMessage("{ProprtyName} can not exceed 200 characters");
        RuleFor(interaction => interaction.Id)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var commentExists = await _unitOfWork.InteractionRepository.GetAsync(id);
                    return commentExists != null;
                }
            )
            .WithMessage("{PropertyName} doesn't exist");

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