using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Comments.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Commands;

public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Unit>
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken token)
    {
        var comment = await _commentRepository.Get(request.Id);

        if (comment == null)
            throw new NotFoundException(nameof(Comment), request.Id);
        
        await _commentRepository.Delete(comment);

        return Unit.Value;
    }
}