using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Post.Validation;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.FollowDTO.Validator
{
    public class FollowDtoValidator : AbstractValidator<FollowDto>
    {
        public FollowDtoValidator(IUserRepository userRepository)
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
                .WithMessage("You can't follow yourself");

        }
    }
}
