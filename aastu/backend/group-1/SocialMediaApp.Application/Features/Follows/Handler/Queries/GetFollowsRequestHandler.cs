using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Follows.Handler.Queries;

public class GetFollowsRequestHandler : IRequestHandler<GetFollowsRequest, List<FollowDto>>
{
    private readonly IFollowRepository _followRepository;
    private readonly IMapper _mapper;

    public GetFollowsRequestHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<List<FollowDto>> Handle(GetFollowsRequest request, CancellationToken cancellationToken)
    {
        var follows = await _followRepository.GetAll();
        return _mapper.Map<List<FollowDto>>(follows);
    }
    
}
