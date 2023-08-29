using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var createValidator = new CreatePostDtoValidator(_unitOfWork.UserRepository);
        var validationResult = await createValidator.ValidateAsync(request.CreatePostDto);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("Post creation failed", errorMessages);
        }
        else
        {
            var post = _mapper.Map<Post>(request.CreatePostDto);
            var newPost = await _unitOfWork.PostRepository.AddAsync(post);
            int success = await _unitOfWork.SaveAsync();

            if (success != 0)
            {
                return CommonResponse<int>.Success(newPost.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Post Creation Failed");
            }
        }
    }
}
