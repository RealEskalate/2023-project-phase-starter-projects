using Application.Contracts.Persistance;
using Application.Features.Like.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Handlers.Query;

public class GetIsLikedQueryHander : IRequestHandler<GetIsLikedQuery, bool>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetIsLikedQueryHander(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<bool> Handle(GetIsLikedQuery request, CancellationToken cancellationToken){
        var exist = _unitOfWork.likeRepository.isLiked(_mapper.Map<Domain.Entities.Like>(request.LikedDto));
        return exist;
    }
}