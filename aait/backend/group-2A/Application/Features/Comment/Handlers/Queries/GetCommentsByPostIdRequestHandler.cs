using Application.Contracts.Persistance;
using Application.DTO.CommentDTO;
using Application.Exceptions;
using Application.Features.Comment.Requests.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comment.Handlers.Queries;

public class GetCommentsByPostIdRequestHandler : IRequestHandler<GetCommentsByPostIdRequest, BaseCommandResponse<List<CommentDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public GetCommentsByPostIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseCommandResponse<List<CommentDto>>> Handle(GetCommentsByPostIdRequest request, CancellationToken cancellationToken)
    {
        try{
            var comments =
                await _unitOfWork.commentRepository.GetCommentByPost(request.PostId, request.PageNumber,
                    request.PageSize);

            if (comments == null){
                throw new NotFoundException(nameof(Domain.Entities.Comment), request.PostId);
            }

            return BaseCommandResponse<List<CommentDto>>.SuccessHandler(_mapper.Map<List<CommentDto>>(comments));
        }
        catch(Exception ex){
                return BaseCommandResponse<List<CommentDto>>.FailureHandler(ex);
        }
    }
}