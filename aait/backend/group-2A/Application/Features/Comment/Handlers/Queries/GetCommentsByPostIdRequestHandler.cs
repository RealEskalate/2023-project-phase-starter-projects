using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentsByPostIdRequestHandler : IRequestHandler<GetCommentsByPostIdRequest, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    
    public GetCommentsByPostIdRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CommentDto>> Handle(GetCommentsByPostIdRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetCommentByPost(request.PostId);

        if (comments == null)
        {
            throw new Exception("No comments");
        }
        
        return _mapper.Map<List<CommentDto>>(comments);
    }
}