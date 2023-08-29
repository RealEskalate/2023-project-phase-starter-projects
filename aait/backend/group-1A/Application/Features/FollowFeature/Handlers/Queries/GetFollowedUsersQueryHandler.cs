using Application.Contracts;
using Application.DTO;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Requests.Queries;
using AutoMapper;
using Domain.Entites;
using MediatR;
namespace Application.Features.FollowFeature.Handlers.Queries
{
    public class GetFollowedUsersQueryHandler : IRequestHandler<GetFollowedUsersQuery,List<UserResponseDTO>>
    {
        IFollowRepository _followRepository;
        IMapper _mapper;
        public GetFollowedUsersQueryHandler(IFollowRepository followRepository,IMapper mapper)
        {
           _followRepository = followRepository; 
           _mapper = mapper;
        }

        public async Task<List<UserResponseDTO>> Handle(GetFollowedUsersQuery request, CancellationToken cancellationToken)
        {
            var followedUsers = await _followRepository.GetFollowedUsers(request.Id);
            var followedUsersDto = _mapper.Map<List<UserResponseDTO>>(followedUsers);
            return followedUsersDto;
        }
    }
}