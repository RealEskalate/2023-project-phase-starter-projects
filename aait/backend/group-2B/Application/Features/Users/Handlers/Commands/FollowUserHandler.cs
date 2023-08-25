using Application.DTOs.Common;
using Application.Features.Users.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;

namespace Applicatin .Features.Users.Handlers.Commands
{
    public class FollowUserHandler : IRequestHandler<FollowUserCommand , Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FollowUserHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<Unit> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var Validator = new FollowUnfollowDtoValidator(_unitOfWork);
            var vallidationResult = await Validator.ValidateAsync(request.FollowUnfollowDto);

            if (!vallidationResult.IsValid) {
                throw new Exception();
                
            }
    

        var user = await _unitOfWork.UserRepository.GetAsync(request.FollowUnfollowDto.FollwerId);
            if (user != null)
            {
                var follower = await user.FindAsync(request.FollowUnfollowDto.FollowedId);

                if (follower == null)
                {
                    _mapper.Map(request.FollowUnfollowDto, user);
                    await user.Followings.AddAsync(follower);
                    await follower.follower.AddAsync(user);

                    
                }
            }
            return Unit.Value;
        }
        

        }
    }

