using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;


namespace SocialMediaApp.Application.DTOs.Follows.Validators
{
    public class IFollowDtoValidator:AbstractValidator<IFollowDto>
    {
        private readonly IUserRepository _userRepository;
        public IFollowDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(n => n.ToBeFollowed)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _userRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
            

            RuleFor(n => n.CurrentUser)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _userRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");

        }

       
        
    }
}