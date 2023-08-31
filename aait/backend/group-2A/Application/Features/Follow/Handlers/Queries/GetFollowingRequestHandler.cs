using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.DTO.FollowDTO;
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
    public class GetFollowingRequestHandler : IRequestHandler<GetFollowingRequest, BaseCommandResponse<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetFollowingRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    
        public async Task<BaseCommandResponse<List<UserDto>>> Handle(GetFollowingRequest request, CancellationToken cancellationToken){
            try{
                var following = await _unitOfWork.followRepository.GetFollowing(request.Id, request.PageNumber,
                    request.PageSize);
                if (following == null){
                   throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
                }
                return BaseCommandResponse<List<UserDto>>.SuccessHandler(_mapper.Map<List<UserDto>>(following));
            }catch(Exception ex){
                return BaseCommandResponse<List<UserDto>>.FailureHandler(ex);
            }
        }
    }
}
