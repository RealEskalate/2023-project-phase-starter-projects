using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.UserDTO;
using Application.Features.FollowFeatures.Request.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Handlers.Queries
{
    public class GetFollowingRequestHandler : IRequestHandler<GetFollowingRequest, List<UserDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;
    
        public GetFollowingRequestHandler(IFollowRepository followRepository, IMapper mapper){
            _followRepository = followRepository;
            _mapper = mapper;
        }
    
        public async Task<List<UserDto>> Handle(GetFollowingRequest request, CancellationToken cancellationToken){
            var following = await _followRepository.GetFollowing(request.Id);
            return _mapper.Map<List<UserDto>>(following);
        }
    }
}
