using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments.Validator
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public CreateCommentDtoValidator(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            Include(new ICommentDtoValidator(_postRepository, _userRepository));
            _userRepository = userRepository;
        }
    }
}
