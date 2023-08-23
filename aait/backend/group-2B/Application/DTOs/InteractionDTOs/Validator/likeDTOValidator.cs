using SocialSync.Application.DTOs.InteractionDTOs;
using FluentValidation;
using Microsoft.VisualBasic;
using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Application.DTOs.InteractionDTOs.Validator
{
    public class LikeDtoValidator : AbstractValidator<InteractionDTO>
    {
        private IPostRepository _IPostRepository;
        private IUserRepository _IUserRepository;

        public LikeDtoValidator(
            IPostRepository IPostRepository,
            IUserRepository IUserRepository
        )
        {
            _IPostRepository = IPostRepository;

            RuleFor(Interaction => Interaction.PostId)
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

            RuleFor(Interaction => Interaction.UserId)
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

   
}
