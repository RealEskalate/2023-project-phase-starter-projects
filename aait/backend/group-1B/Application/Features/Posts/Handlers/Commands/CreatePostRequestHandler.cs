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
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Post> Handle(CreatePostRequest request, CancellationToken token)
    {
        var validator = new CreatePostDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Post, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);
        
        // Add the post
        var post =  await _unitOfWork.PostRepository.Add(_mapper.Map<Post>(request.Post));
        await _unitOfWork.Save();
        // Add the hashtags
        var tags = PostTagHelpers.GetTags(request.Post.Content);
        foreach (var tag in tags)
        {
            await _unitOfWork.PostTagRepository.AddTagToPost(post.Id, tag);
        }

        await _unitOfWork.Save();
        return post;
    }
}