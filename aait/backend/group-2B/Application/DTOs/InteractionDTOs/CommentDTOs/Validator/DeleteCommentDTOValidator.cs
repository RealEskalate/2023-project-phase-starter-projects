using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

public class DeleteCommentDtoValidator : AbstractValidator<DeleteCommentInteractionDto>
{
    private IUnitOfWork _unitOfWork;

    public DeleteCommentDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(interaction => interaction.Id)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var postExists = await _unitOfWork.InteractionRepository.GetAsync(id);
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