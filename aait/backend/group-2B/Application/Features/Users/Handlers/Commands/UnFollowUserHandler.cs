using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Handlers.Commands
{
    public class UnFollowUserHandler : IRequestHandler<UnFollowUserCommand ,Unit>
    {
        private readonly IUserRepository _userRepository;
        private   IUnitOfWork _unitOfWork;

        public UnFollowUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle( UnFollowUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new FollowUnfollowDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.UnfollowunFollowDto);

            if (!validationResult.IsValid)
            {
                
                throw new Exception("Validation failed.");
            }

        var user = await _userRepository.GetAsync(request.UnfollowunFollowDto.FollwerId);

            var follower = await _userRepository.GetAsync(request.UnfollowunFollowDto.FollowedId);
            if (follower != null)
            {
                await follower.follwer.DeleteAsync(user);
                await user.Followings.DeleteAsync(follower);
            }


            return Unit.Value;
        }
    }
    }

