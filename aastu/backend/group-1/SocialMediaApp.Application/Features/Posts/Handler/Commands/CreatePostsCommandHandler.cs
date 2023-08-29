using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Posts.Validators;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Handler.Commands;

public class CreatePostsCommandHandler : IRequestHandler<CreatePostsCommand,BaseResponseClass>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreatePostsCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        
    }

    public async Task<BaseResponseClass> Handle(CreatePostsCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.postDto, cancellationToken);
        var response = new BaseResponseClass();
        if(validationResult.IsValid == true)
        {
            var post = _mapper.Map<Post>(request.postDto);
            post = await _postRepository.Add(post);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = post.Id;
        }
        else
        {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
       
        return response;
    }
}
