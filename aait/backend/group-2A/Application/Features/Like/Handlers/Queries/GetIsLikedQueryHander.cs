using Application.Contracts.Persistance;
using Application.Features.Like.Request.Queries;
using AutoMapper;
using MediatR;
using Application.Responses;

namespace Application.Features.Like.Handlers.Query
{
    public class GetIsLikedQueryHander : IRequestHandler<GetIsLikedQuery, BaseCommandResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetIsLikedQueryHander(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<bool>> Handle(GetIsLikedQuery request, CancellationToken cancellationToken)
        {
            var exist = await _unitOfWork.likeRepository.isLiked(_mapper.Map<Domain.Entities.Like>(request.LikedDto));
            return BaseCommandResponse<bool>.SuccessHandler(exist);
        }
    }
}
