using Application.features.Users.Request.command;

using MediatR;
using Application.Contracts.Persistence;

namespace Application.features.Users.Handler.Command
{
    public class UnfollowUserRequestHandler : IRequestHandler<UnfollowUserRequest, bool>
    {
        private readonly IUserRepository _userRepository;

        public UnfollowUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UnfollowUserRequest request, CancellationToken cancellationToken)
        {
           return await _userRepository.UnFollowUser(request.followDto.FollowerId, request.followDto.FolloweeId);
        }
    }
}
