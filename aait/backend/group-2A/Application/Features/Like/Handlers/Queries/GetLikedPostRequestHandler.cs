using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Like.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Handlers.Query;

public class GetLikedPostRequestHandler : IRequestHandler<GetLikedPostRequest, List<PostDto>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLikedPostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetLikedPostRequest request, CancellationToken cancellationToken){
        var posts = await _unitOfWork.likeRepository.GetLikedPost(request.Id);
        return _mapper.Map<List<PostDto>>(posts);

    }
}