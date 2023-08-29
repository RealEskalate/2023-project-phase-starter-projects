using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;


namespace SocialMediaApp.Application.DTOs.Follows.Validators
{
    public class ValidateCreateFollow:AbstractValidator<CreateFollowDto>
    {
        private readonly IUserRepository _userRepository;
        public ValidateCreateFollow(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            Include(new IFollowDtoValidator(_userRepository));
        }
        
    }
}