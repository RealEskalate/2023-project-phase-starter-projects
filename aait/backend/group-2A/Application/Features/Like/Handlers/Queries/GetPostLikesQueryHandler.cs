using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.Like;
using AutoMapper;

namespace Application.Features.Like.Handlers.Query
{
    public class GetPostLikesQueryHandler : IRequestHandler<GetPostLikesQuery, List<LikedDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostLikesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LikedDto>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var likes = await _unitOfWork.likeRepository.GetLikers(request.Id);
            return _mapper.Map<List<LikedDto>>(likes);
        }
    }
}