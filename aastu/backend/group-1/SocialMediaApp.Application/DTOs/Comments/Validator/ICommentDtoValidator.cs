using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments.Validator
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public ICommentDtoValidator(IPostRepository postRepository, IUserRepository userRepository)
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
                   var PostIdExists = await _postRepository.Exists(id);
                   return PostIdExists;
               })
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(n => n.Text)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            
        }

    }
}
