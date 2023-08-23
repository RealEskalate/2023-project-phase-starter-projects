using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, CommentDto>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentRequestHandler (ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.commentId);
        if (comment == null)
        {
            throw new Exception("Could not find comment");
        }

        return _mapper.Map<CommentDto>(comment);
    }
}