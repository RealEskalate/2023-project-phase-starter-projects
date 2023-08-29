using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Follows.Handler.Queries
{
    public class GetFollowRequestHandler : IRequestHandler<GetFollowerRequest, List<FollowDto>>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public GetFollowRequestHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<List<FollowDto>>  Handle(GetFollowerRequest request, CancellationToken cancellationToken)
        {
            var follow = await _followRepository.GetFollowersAsync(request.userId);
            var followersData = _mapper.Map<List<FollowDto>>(follow);
            return followersData;
        }


    }
}