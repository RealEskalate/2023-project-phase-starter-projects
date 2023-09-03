using System.Runtime.CompilerServices;
using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Posts.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Queries;

public class GetPostRequestHandler : IRequestHandler<GetPostRequest, Post>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetPostRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<Post> Handle(GetPostRequest request, CancellationToken token)
    {
        var post = await _postRepository.Get(request.Id);
        if (post == null)
            throw new NotFoundException(nameof(Post), request.Id);

        return post;
    }
}