using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : PostsRequestHandler, IRequestHandler<CreatePostCommand, CommonResponse<int>>
{
    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<CommonResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var createValidator = new CreatePostDtoValidator(_userRepository);
        var validationResult = await createValidator.ValidateAsync(request.CreatePostDto);
        CommonResponse<int> response;

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            response = CommonResponse<int>.FailureWithError("Post creation failed", errorMessages);
        }
        else
        {
            var post = _mapper.Map<Post>(request.CreatePostDto);
            var newPost = await _postRepository.AddAsync(post);
            await _unitOfWork.SaveAsync();

            response = CommonResponse<int>.Success(newPost.Id);
        }
        return response;
    }
}
