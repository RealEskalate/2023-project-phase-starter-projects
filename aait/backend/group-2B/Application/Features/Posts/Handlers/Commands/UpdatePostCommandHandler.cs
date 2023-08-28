using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.DTOs.PostDtos.Validators;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler :  IRequestHandler<UpdatePostCommand, CommonResponse<Unit>>
{

    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Unit>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var updateValidator = new UpdatePostDtoValidator(_unitOfWork.UserRepository,_unitOfWork.PostRepository);
        var updateValidationResult = await updateValidator.ValidateAsync(request.UpdatePostDto);

        if (!updateValidationResult.IsValid)
        {
            var errorMessages = updateValidationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<Unit>.FailureWithError("Post update failed", errorMessages);
        }

        else
        {
            var post = await _unitOfWork.PostRepository.GetAsync(request.UpdatePostDto.Id);
            _mapper.Map(request.UpdatePostDto, post);

            await _unitOfWork.PostRepository.UpdateAsync(post);
            int success = await _unitOfWork.SaveAsync();
            if (success > 0)
            {
                return CommonResponse<Unit>.Success(Unit.Value);

            }
            else
            {
                return CommonResponse<Unit>.Failure("Post Update Failed");
            }
        }
    }
}