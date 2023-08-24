using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Exceptions;
using Application.Features.Comment.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, CommentDto>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.commentRepository.Get(request.commentId);
        if (comment == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.commentId);
        }

        return _mapper.Map<CommentDto>(comment);
    }
}