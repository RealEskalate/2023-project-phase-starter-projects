using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;


namespace Application.Features.Users.Handlers.Commands
{
    public class UnFollowUserHandler : IRequestHandler<UnFollowUserCommand ,Unit>
    {
        private readonly IUserRepository _userRepository;
        private  readonly  IUnitOfWork _unitOfWork;

        public UnFollowUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle( UnFollowUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UnFollowDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.UnfollowunFollowDto);

            if (!validationResult.IsValid)
            {
                
                throw new Exception("Validation failed.");
            }

            await  _unitOfWork.UserRepository.UnFOllowUser(request.UnfollowunFollowDto.FollwerId,request.UnfollowunFollowDto.FollowedId);

            await _unitOfWork.SaveAsync();


            return Unit.Value;
        }
    }
    }

