using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Posts;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostsByTagRequestHandler : IRequestHandler<GetPostsByTagRequest, List<PostContentDto>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostsByTagRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<PostContentDto>> Handle(GetPostsByTagRequest request, CancellationToken token)
    {
        var posts = await _postRepository.GetByTag(request.Tag);
        return _mapper.Map<List<PostContentDto>>(posts);
    }
}