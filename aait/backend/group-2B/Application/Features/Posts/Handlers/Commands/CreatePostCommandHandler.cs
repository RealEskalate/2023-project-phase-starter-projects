using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.DTOs.PostDtos.Validators;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : PostsRequestHandler, IRequestHandler<CreatePostCommand, GeneralPostDto>
{
    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<GeneralPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {

        var CreateValidator = new CreatePostDtoValidator(_postRepository);
        var ValidationResult = CreateValidator.Validate(request.CreatePostDto);

        // to be implemented after Response object is created

        // if(!ValidationResult.IsValid){
        //     throw new InvalidPostInputException(ValidationResult.Errors.ToString());
        // }

        var post = _mapper.Map<Post>(request.CreatePostDto);
        await _postRepository.AddAsync(post);
        return _mapper.Map<GeneralPostDto>(post);
    }
}