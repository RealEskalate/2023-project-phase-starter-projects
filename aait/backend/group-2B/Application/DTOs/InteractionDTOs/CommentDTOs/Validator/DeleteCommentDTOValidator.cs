using FluentValidation;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Common;

namespace SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs.Validator;

public class DeleteCommentDtoValidator : AbstractValidator<DeleteCommentInteractionDTO>
{
    private IInteractionRepository _IInteractionRepository;

    public DeleteCommentDtoValidator(IInteractionRepository iInteractionRepository)
    {
        _IInteractionRepository = iInteractionRepository;
        RuleFor(interaction => interaction.Id)
            .GreaterThan(0)
            .MustAsync(
                async (id, token) =>
                {
                    var postExists = await _IInteractionRepository.GetAsync(id);
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