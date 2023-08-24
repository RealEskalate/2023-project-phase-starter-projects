using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Queries;

public class GetByContentRequestHandler : IRequestHandler<GetByContenetRequest, List<PostDto>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByContentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PostDto>> Handle(GetByContenetRequest request, CancellationToken cancellationToken){
        var posts = await _unitOfWork.postRepository.GetByContent(request.Contenet);
        return _mapper.Map<List<PostDto>>(posts);
    }
}