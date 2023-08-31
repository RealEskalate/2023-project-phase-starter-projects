using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;

namespace Application.Features.Users.Handlers.Commands;

public class UnFollowUserCommandHandler
    : IRequestHandler<UnFollowUserCommandRequest, CommonResponse<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UnFollowUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<CommonResponse<int>> Handle(
        UnFollowUserCommandRequest request,
        CancellationToken cancellationToken
    )
    {
        var validator = new UnFollowDtoValidator(_unitOfWork);
        var validationResult = await validator.ValidateAsync(request.UnfollowDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.Failure("unfollow failed");
        }

        await _unitOfWork.UserRepository.UnfollowUser(
            request.UnfollowDto.FollwerId,
            request.UnfollowDto.FollowedId
        );

        await _unitOfWork.SaveAsync();

        return new CommonResponse<int> { IsSuccess = true, Error = "" };
    }
}
