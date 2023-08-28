using SocialSync.Application.DTOs.InteractionDTOs;
using FluentValidation;
using Microsoft.VisualBasic;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.Validator
{
    public class LikeDtoValidator : AbstractValidator<InteractionDto>
    {
        private readonly IUnitOfWork _unitOfWork;

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

   
}
