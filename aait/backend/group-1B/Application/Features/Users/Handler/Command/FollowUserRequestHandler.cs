using Application.features.Users.Request.command;
using MediatR;
using Application.Contracts.Persistence;

namespace Application.features.Users.Handler.Command
{
    public class FollowUserRequestHandler : IRequestHandler<FollowUserRequest, bool>
    {
        private readonly IUserRepository _userRepository;

        public FollowUserRequestHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(FollowUserRequest request, CancellationToken cancellationToken)
        {
            return await _userRepository.FollowUser(request.followDto.FollowerId, request.followDto.FolloweeId);
        }
    }
}
