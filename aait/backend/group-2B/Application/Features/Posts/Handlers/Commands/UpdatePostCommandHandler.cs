using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler : PostsRequestHandler, IRequestHandler<UpdatePostCommand, CommonResponse<Unit>>
{
    public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<CommonResponse<Unit>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var updateValidator = new UpdatePostDtoValidator(_userRepository, _postRepository);
        var updateValidationResult = await updateValidator.ValidateAsync(request.UpdatePostDto);
        CommonResponse<Unit> response;

        if (!updateValidationResult.IsValid)
        {
            var errorMessages = updateValidationResult.Errors.Select(q => q.ErrorMessage).ToList();
            response = CommonResponse<Unit>.FailureWithError("Post update failed", errorMessages);
        }

        else
        {
            var post = await _postRepository.GetAsync(request.UpdatePostDto.Id);
            _mapper.Map(request.UpdatePostDto, post);

            await _postRepository.UpdateAsync(post);
            await _unitOfWork.SaveAsync();

            response = CommonResponse<Unit>.Success(Unit.Value);
        }
        return response;


    }
}