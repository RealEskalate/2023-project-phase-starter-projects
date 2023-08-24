using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using AutoMapper;

namespace Application.Features.Like.Handlers.Query
{
    public class GetPostLikesQueryHandler : IRequestHandler<GetPostLikesQuery, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostLikesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserDto>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var likes = await _unitOfWork.likeRepository.GetLikers(request.Id);
            return _mapper.Map<List<UserDto>>(likes);
        }
    }
}