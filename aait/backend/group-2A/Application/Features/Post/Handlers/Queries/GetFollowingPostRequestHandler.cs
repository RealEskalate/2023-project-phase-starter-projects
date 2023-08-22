using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Queries;

public class GetFollowingPostRequestHandler : IRequestHandler<GetFollowingPostRequest, List<PostDto>>{
    
    private readonly IPostRepository _postRepository;
    private readonly Mapper _mapper;

    public GetFollowingPostRequestHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostDto>> Handle(GetFollowingPostRequest request, CancellationToken cancellationToken){
        var posts = await _postRepository.GetFollowingPost(request.Id);

        return _mapper.Map<List<PostDto>>(posts);
    }
}