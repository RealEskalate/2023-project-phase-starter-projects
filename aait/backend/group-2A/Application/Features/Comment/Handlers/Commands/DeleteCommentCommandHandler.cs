using Application.Contracts.Persistance;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class DeleteCommentCommandHandler :  IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.Get(request.Id);
        
        if (comment == null)
        {
            throw new Exception();
        }
        
        
        await _commentRepository.Delete(comment);
        return Unit.Value;
    }
}