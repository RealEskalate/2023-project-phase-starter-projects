using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Posts.Validators;
using Application.Features.Posts.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class CreatePostRequestHandler : IRequestHandler<CreatePostRequest, Post>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CreatePostRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Post> Handle(CreatePostRequest request, CancellationToken token)
    {
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Post, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        var post =  await _postRepository.Add(_mapper.Map<Post>(request.Post));

        return post;
    }
}