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
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetFollowersQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
        _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public async Task<BaseResponse<List<UserResponseDTO>>> Handle(GetFollowersQuery request, CancellationToken cancellationToken)
        {
            var followers = await _unitOfWork.FollowRepository.GetFollowers(request.Id);
            var followersDto = _mapper.Map<List<UserResponseDTO>>(followers);

            return new BaseResponse<List<UserResponseDTO>>() {

                Success = true,
                Message = "List of users that follow you",
                Value = followersDto
            };
        }
    }
}