using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class RemovePostCommandHandler : PostsRequestHandler, IRequestHandler<RemovePostCommand, CommonResponse<Unit>>
{
    public RemovePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<CommonResponse<Unit>> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        var removePostValidator = new RemovePostDtoValidator(_userRepository, _postRepository);
        var validationResult = await removePostValidator.ValidateAsync(request.RemovePostDto);
        CommonResponse<Unit> response;

        if (validationResult.IsValid)
        {

            var post = await _postRepository.GetAsync(request.RemovePostDto.Id);
            await _postRepository.DeleteAsync(post);
            await _unitOfWork.SaveAsync();

            response = CommonResponse<Unit>.Success(Unit.Value);
        }
        else
        {
            response = CommonResponse<Unit>.FailureWithError("Post Deletion Failed", validationResult.Errors.Select(q => q.ErrorMessage));
        }
        return response;
    }
}