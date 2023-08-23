using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Posts.Validators;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, Post>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public UpdatePostRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Post> Handle(UpdatePostRequest request, CancellationToken token)
    {
        var validator = new UpdatePostDtoValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request.Post, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        Post postToUpdate = _mapper.Map<Post>(request.Post);
        var post = await _postRepository.Update(postToUpdate);

        return post;
    }
}