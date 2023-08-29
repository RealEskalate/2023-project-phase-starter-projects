using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts.Validators
{
    public class CreatePostDtoValidator: AbstractValidator<CreatePostDto>
    {
        private readonly IPostRepository _postRepository;
        public CreatePostDtoValidator(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            Include(new IPostDtoValidator(_postRepository));
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed 30 characters. ");
            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters. ");


        }

    }
}
