using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.DTOs.PostDtos.Validators;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Responses;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : PostsRequestHandler, IRequestHandler<CreatePostCommand, BaseCommandResponse>
{
    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<BaseCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {

        var CreateValidator = new CreatePostDtoValidator(_postRepository);
        var ValidationResult = CreateValidator.Validate(request.CreatePostDto);
        var response =  new BaseCommandResponse();
    
        if(!ValidationResult.IsValid){

            response.Success = false;
            response.Message = $"Post Creation Failed";
            response.Errors = ValidationResult.Errors.Select(q=>q.ErrorMessage).ToList();

        }


        var post = _mapper.Map<Post>(request.CreatePostDto);
        var newPost = await _postRepository.AddAsync(post);

        response.Success = true;
        response.Message = "Post Created Successful.";
        response.Id = newPost.Id;


        return response;
    }
}