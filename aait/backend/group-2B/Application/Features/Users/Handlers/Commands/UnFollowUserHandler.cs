using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;


namespace Application.Features.Users.Handlers.Commands
{
    public class UnFollowUserHandler : IRequestHandler<UnFollowUserCommand , CommonResponse<int>    >
    {
        private readonly IUserRepository _userRepository;
        private  readonly  IUnitOfWork _unitOfWork;

        public UnFollowUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<CommonResponse<int>> Handle( UnFollowUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UnFollowDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.UnfollowunFollowDto);

            if (!validationResult.IsValid)
            {
                
                return CommonResponse<int>.Failure("unfollow failed");
            }

            await  _unitOfWork.UserRepository.UnFOllowUser(request.UnfollowunFollowDto.FollwerId,request.UnfollowunFollowDto.FollowedId);

            await _unitOfWork.SaveAsync();


            return CommonResponse<int>.Success(1);
        }
    }
    }

