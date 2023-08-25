using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

public class DeleteCommentDtoValidator : AbstractValidator<DeleteCommentInteractionDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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