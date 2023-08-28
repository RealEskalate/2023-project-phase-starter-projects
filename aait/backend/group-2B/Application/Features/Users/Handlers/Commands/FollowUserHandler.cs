using Application.Features.Users.Requests.Commands;
using AutoMapper;
using MediatR;
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
                var validator = new FollowUnfollowDtoValidator(_unitOfWork);
                var vallidationResult = await validator.ValidateAsync(request.FollowUnfollowDto);

                if (!vallidationResult.IsValid) {
                    throw new Exception();
                    
                }
        
            await _unitOfWork.UserRepository.FollowUser(request.FollowUnfollowDto.FollwerId,request.FollowUnfollowDto.FollowedId);

            await _unitOfWork.SaveAsync();

        
            return Unit.Value;
        }
        

        }
    }

