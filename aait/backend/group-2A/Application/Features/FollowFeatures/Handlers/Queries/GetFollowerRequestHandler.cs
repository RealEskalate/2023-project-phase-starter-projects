using Application.Contracts.Persistance;
using Application.DTO.FollowDTO;
using Application.DTO.Post;
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
    public class GetFollowerRequestHandler : IRequestHandler<GetFollowerRequest, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFollowerRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDto>> Handle(GetFollowerRequest request, CancellationToken cancellationToken)
        {
            var followers = await _unitOfWork.followRepository.GetFollower(request.Id);
            return _mapper.Map<List<UserDto>>(followers);
        }
    }
}
