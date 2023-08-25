using Application.Contracts.Persistance;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class DeleteCommentCommandHandler :  IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _unitOfWork.commentRepository.Get(request.Id);
        
        if (comment == null || comment.UserId != request.UserId)
        {
            throw new Exception("You Dont Have Access");
        }
        
        
        await _unitOfWork.commentRepository.Delete(comment);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}