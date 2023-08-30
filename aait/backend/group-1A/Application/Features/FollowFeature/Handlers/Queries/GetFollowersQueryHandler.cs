using Application.Contracts;
using Application.DTO;
using Application.DTO.UserDTO.DTO;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;
namespace Application.Features.FollowFeature.Handlers.Queries
{
    public class GetFollowersQueryHandler : IRequestHandler<GetFollowersQuery,BaseResponse<List<UserResponseDTO>>>
    {
        IFollowRepository _followRepository;
        IMapper _mapper;
        public GetFollowersQueryHandler(IFollowRepository followRepository,IMapper mapper)
        {
           _followRepository = followRepository; 
           _mapper = mapper;
        }

        public async Task<BaseResponse<List<UserResponseDTO>>> Handle(GetFollowersQuery request, CancellationToken cancellationToken)
        {
            var followers = await _followRepository.GetFollowers(request.Id);
            var followersDto = _mapper.Map<List<UserResponseDTO>>(followers);

            return new BaseResponse<List<UserResponseDTO>>() {

                Success = true,
                Message = "List of users that follow you",
                Value = followersDto
            };
        }
    }
}