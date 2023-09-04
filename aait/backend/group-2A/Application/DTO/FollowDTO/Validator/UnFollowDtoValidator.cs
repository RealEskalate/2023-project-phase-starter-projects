using Application.Contracts.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.FollowDTO.Validator
{
    public class UnFollowDtoValidator : AbstractValidator<FollowDto>
    {
        public UnFollowDtoValidator(IUserRepository userRepository, IFollowRepository followRepository)
        {
            RuleFor(p => p.FollowerId)
                .NotEmpty().WithMessage("{PropertyName} is Invalid.")
                .NotNull()
                .MustAsync(async (id, cancellation) => {
                    var exist = await userRepository.Exists(id);
                    return exist;
                }).WithMessage("User not found");

            RuleFor(p => p.FollowedId)
                .NotEmpty().WithMessage("{PropertyName} is Invalid.")
                .NotNull()
                .MustAsync(async (id, cancellation) => {
                    var exist = await userRepository.Exists(id);
                    return exist;
                }).WithMessage("User not found");

            RuleFor(p => p)
                .Must((follow, cancellation) =>
                {
                    return follow.FollowerId != follow.FollowedId;
                })
                .WithMessage("You can't Unfollow yourself");

            RuleFor(p => p)
                .MustAsync(async (followDto, cancellation) =>
                {
                    var followRelationshipExists = await followRepository.FollowRelationshipExists(
                        followDto.FollowerId, followDto.FollowedId);

                    return followRelationshipExists;
                })
                .WithMessage("You are Not following this user");

        }
    }
}
