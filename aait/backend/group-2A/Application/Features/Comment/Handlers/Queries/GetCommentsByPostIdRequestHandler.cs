using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentsByPostIdRequestHandler : IRequestHandler<GetCommentsByPostIdRequest, List<CommentDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public GetCommentsByPostIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CommentDto>> Handle(GetCommentsByPostIdRequest request, CancellationToken cancellationToken)
    {
        var comments = await _unitOfWork.commentRepository.GetCommentByPost(request.PostId);

        if (comments == null)
        {
            throw new Exception("No comments");
        }
        
        return _mapper.Map<List<CommentDto>>(comments);
    }
}