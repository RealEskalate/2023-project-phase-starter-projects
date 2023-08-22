using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries;

public class GetCommentsByPostIdRequestHandler : IRequestHandler<GetCommentsByPostIdRequest, List<CommentContentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public GetCommentsByPostIdRequestHandler(ICommentRepository commentRepository, IPostRepository postRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentContentDto>> Handle(GetCommentsByPostIdRequest request, CancellationToken token)
    {
        var post = await _postRepository.Get(request.PostId);
        if (post == null)
            throw new NotFoundException(nameof(Post), request.PostId);
        
        var comments = (await _commentRepository.GetByPostId(request.PostId)).ToList();

        return _mapper.Map<List<CommentContentDto>>(comments);
    }
}