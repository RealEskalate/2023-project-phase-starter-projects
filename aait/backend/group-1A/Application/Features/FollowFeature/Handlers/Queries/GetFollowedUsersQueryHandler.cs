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
    public class GetFollowedUsersQueryHandler : IRequestHandler<GetFollowedUsersQuery,BaseResponse<List<UserResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public GetFollowedUsersQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
        _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public async Task<BaseResponse<List<UserResponseDTO>>> Handle(GetFollowedUsersQuery request, CancellationToken cancellationToken)
        {
            var followedUsers = await _unitOfWork.FollowRepository.GetFollowedUsers(request.Id);

            return new BaseResponse<List<UserResponseDTO>> () {
                Success =  true,
                Message = "List of Users followed by you",
                Value = _mapper.Map<List<UserResponseDTO>>(followedUsers)
            };
        }
    }
}