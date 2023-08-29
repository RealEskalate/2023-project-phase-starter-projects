using FluentValidation;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Likes.Validators
{
    public class ILikeDtoValidator: AbstractValidator<ILikeDto> {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public ILikeDtoValidator(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            RuleFor(n => n.UserId)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _userRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.PostId)
            .MustAsync(async (id, token) =>
            {
                var UserIdExists = await _postRepository.Exists(id);
                return UserIdExists;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }

}

