using FluentValidation;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Posts.Validators;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    private readonly IPostRepository _postRepository;
    public UpdatePostDtoValidator(IPostRepository postRepository)
    {
        _postRepository = postRepository;
        Include(new IPostDtoValidator(_postRepository));
    }
}
