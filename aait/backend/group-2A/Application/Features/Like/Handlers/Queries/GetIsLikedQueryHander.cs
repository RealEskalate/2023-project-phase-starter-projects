using Application.Contracts.Persistance;
using Application.Features.Like.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Handlers.Query;

public class GetIsLikedQueryHander : IRequestHandler<GetIsLikedQuery, bool>{
    private ILikeRepository _likeRepository;
    private Mapper _mapper;

    public GetIsLikedQueryHander(ILikeRepository likeRepository){
        _likeRepository = likeRepository;
    }

    public Task<bool> Handle(GetIsLikedQuery request, CancellationToken cancellationToken){
        var exist = _likeRepository.isLiked(_mapper.Map<Domain.Entities.Like>(request.LikedDto));
        return exist;
    }
}