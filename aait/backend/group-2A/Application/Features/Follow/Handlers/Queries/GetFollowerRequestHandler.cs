using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.DTO.FollowDTO;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Application.Exceptions;
using Application.Features.FollowFeatures.Request.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Handlers.Queries
{
    public class GetFollowerRequestHandler : IRequestHandler<GetFollowerRequest, BaseCommandResponse<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFollowerRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<List<UserDto>>> Handle(GetFollowerRequest request, CancellationToken cancellationToken)
        {
            var followers = await _unitOfWork.followRepository.GetFollower(request.Id);
            if (followers == null)
            {
                var notFoundException = new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
                return BaseCommandResponse<List<UserDto>>.FailureHandler(notFoundException);
            }
            return BaseCommandResponse<List<UserDto>>.SuccessHandler(_mapper.Map<List<UserDto>>(followers));
        }
    }
}
