using SocialSync.Application.DTOs.InteractionDTOs;
using FluentValidation;
using Microsoft.VisualBasic;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.Validator
{
    public class LikeDtoValidator : AbstractValidator<InteractionDto>
    {
        private IUnitOfWork _unitOfWork;

        public LikeDtoValidator(
           IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;

            RuleFor(interaction => interaction.PostId)
                .GreaterThan(0)
                .MustAsync(
                    async (id, token) =>
                    {
                        var postExists = await _unitOfWork.PostRepository.GetAsync(id);
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
                        var postExists = await _unitOfWork.UserRepository.GetAsync(id);
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

   
}
