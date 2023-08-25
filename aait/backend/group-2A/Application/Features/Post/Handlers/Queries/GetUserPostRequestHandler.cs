using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Queries;

public class GetUserPostRequestHandler : IRequestHandler<GetUserPostRequest, List<PostDto>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserPostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PostDto>> Handle(GetUserPostRequest request, CancellationToken cancellationToken){
        var posts = await _unitOfWork.postRepository.GetUserPost(request.Id);
        return _mapper.Map<List<PostDto>>(posts);
    }
}