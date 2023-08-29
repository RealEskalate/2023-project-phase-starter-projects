using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Comments.Validator
{
    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public UpdateCommentDtoValidator(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;

            Include(new ICommentDtoValidator(_postRepository,_userRepository));
        }
    }
}
