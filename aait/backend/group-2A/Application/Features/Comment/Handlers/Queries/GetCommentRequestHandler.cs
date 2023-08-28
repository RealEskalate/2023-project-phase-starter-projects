using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Exceptions;
using Application.Features.Comment.Requests.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, BaseCommandResponse<CommentDto>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseCommandResponse<CommentDto>> Handle(GetCommentRequest request, CancellationToken cancellationToken)
    {
        try{
            var comment = await _unitOfWork.commentRepository.Get(request.commentId);
            if (comment == null){
                throw new NotFoundException(nameof(Domain.Entities.Comment), request.commentId);
            }
            return BaseCommandResponse<CommentDto>.SuccessHandler(_mapper.Map<CommentDto>(comment));
        } catch(Exception ex){
            return BaseCommandResponse<CommentDto>.FailureHandler(ex);
        }
    }
}