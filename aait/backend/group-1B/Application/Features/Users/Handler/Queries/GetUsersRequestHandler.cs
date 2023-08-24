using AutoMapper;
using Application.DTOs.Users;
using MediatR;
using Application.Contracts.Persistence;
using Application.Features.Users.Request;

namespace Application.features.Users.Handler.Queries
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, List<UserListDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{request.Id} {request.getFollowers}");


            var users = await _userRepository.GetUsers(request.Id, request.getFollowers);

            

            var usersDto = _mapper.Map<List<UserListDto>>(users);

            return usersDto;
        }
    }
}
