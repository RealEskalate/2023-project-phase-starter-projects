using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Queries;

public class GetByTagRequestHandler : IRequestHandler<GetByTagRequest, List<PostDto>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByTagRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PostDto>> Handle(GetByTagRequest request, CancellationToken cancellationToken){
        var posts = await _unitOfWork.postRepository.GetBytag(request.Tag);
        return _mapper.Map<List<PostDto>>(posts);
    }
}