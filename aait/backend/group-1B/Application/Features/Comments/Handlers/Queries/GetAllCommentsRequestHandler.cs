using Application.Contracts.Persistence;
using Application.DTOs.Comments;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries;

public class GetAllCommentsRequestHandler : IRequestHandler<GetAllCommentsRequest, List<CommentContentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetAllCommentsRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentContentDto>> Handle(GetAllCommentsRequest request, CancellationToken token)
    {
        var comments = (await _commentRepository.GetAll()).ToList();
        return _mapper.Map<List<CommentContentDto>>(comments);
    }
}