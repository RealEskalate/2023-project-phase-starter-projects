using AutoMapper;
using Application.DTOs.Users;
using MediatR;
using Application.Features.Users.Request;
using Application.Contracts.Persistence;

namespace Application.features.Users.Handler.Queries
{
    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDetail>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDetail> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserDetail(request.Id);

            var userDetail = _mapper.Map<UserDetail>(user);

            return userDetail;
        }
    }
}
