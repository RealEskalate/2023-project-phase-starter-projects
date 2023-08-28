using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler :IRequestHandler<DeletePostCommand, CommonResponse<Unit>>
{

    private IUnitOfWork _unitOfWork;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;

    }

    public async Task<CommonResponse<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var removePostValidator = new DeletePostDtoValidator(_unitOfWork.UserRepository, _unitOfWork.PostRepository);
        var validationResult = await removePostValidator.ValidateAsync(request.DeletePostDto);

        if (validationResult.IsValid)
        {
            var post = await _unitOfWork.PostRepository.GetAsync(request.DeletePostDto.Id);
            await _unitOfWork.PostRepository.DeleteAsync(post);
            int success = await _unitOfWork.SaveAsync();
            if (success > 0)
            {
                return CommonResponse<Unit>.Success(Unit.Value);
            }
            else
            {
                return CommonResponse<Unit>.Failure("Post Deletion Failed");
            }
        }
        else
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<Unit>.FailureWithError("Post Deletion Failed", errorMessages);
        }
    }
}