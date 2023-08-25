using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Posts.Validators;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class UpdatePostRequestHandler : IRequestHandler<UpdatePostRequest, Post>
{
   
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Post> Handle(UpdatePostRequest request, CancellationToken token)
    {
        var validator = new UpdatePostDtoValidator(_unitOfWork.PostRepository);
        var validationResult = await validator.ValidateAsync(request.Post, token);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var oldPost = await _unitOfWork.PostRepository.Get(request.Post.Id);
        var oldContent = oldPost.Content;
        oldPost.Content = request.Post.Content;
        oldPost.Title = request.Post.Title;

        var oldTags = PostTagHelpers.GetTags(oldContent);
        var newTags = PostTagHelpers.GetTags(request.Post.Content);
        var differences = PostTagHelpers.GetTagDifferences(oldTags, newTags);

        foreach (var addedTag in differences.Item1)
        {
            await _unitOfWork.PostTagRepository.AddTagToPost(oldPost.Id, addedTag);
        }

        foreach (var removedTag in differences.Item2)
        {
            await _unitOfWork.PostTagRepository.DeletePostTag(oldPost.Id, removedTag);
        }
        
        await _unitOfWork.Save();
        return oldPost;
    }
}