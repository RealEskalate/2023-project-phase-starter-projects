using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.Features.User.Request.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                UserName = request.CreateUser.UserName,
                Email = request.CreateUser.Email,
                FullName = request.CreateUser.FullName,
                Bio = request.CreateUser.Bio,
                Password = request.CreateUser.Password
                // You might need to hash the password before saving
            };

            await _userRepository.AddUserAsync(user);

            return user.Id;
        }
    }
}
