using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Queries;

public class GetByTagRequestHandler : IRequestHandler<GetByTagRequest, List<PostDto>>{
    
    private readonly IPostRepository _postRepository;
    private readonly Mapper _mapper;

    public GetByTagRequestHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetByTagRequest request, CancellationToken cancellationToken){
        var posts = await _postRepository.GetBytag(request.Tag);
        return _mapper.Map<List<PostDto>>(posts);
    }
}