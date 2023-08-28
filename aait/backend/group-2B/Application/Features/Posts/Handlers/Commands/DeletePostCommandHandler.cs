using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler : PostsRequestHandler, IRequestHandler<DeletePostCommand, CommonResponse<Unit>>
{
    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<CommonResponse<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var removePostValidator = new RemovePostDtoValidator(_userRepository, _postRepository);
        var validationResult = await removePostValidator.ValidateAsync(request.DeletePostDto);
        CommonResponse<Unit> response;

        if (validationResult.IsValid)
        {

            var post = await _postRepository.GetAsync(request.DeletePostDto.Id);
            await _postRepository.DeleteAsync(post);
            await _unitOfWork.SaveAsync();

            response = CommonResponse<Unit>.Success(Unit.Value);
        }
        else
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            response = CommonResponse<Unit>.FailureWithError("Post Deletion Failed", errorMessages);
        }
        return response;
    }
}