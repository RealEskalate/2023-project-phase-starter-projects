using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Comments.Requests.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Handlers.Queries;

public class GetCommentRequestHandler : IRequestHandler<GetCommentRequest, Comment> 
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Comment> Handle(GetCommentRequest request, CancellationToken token)
    {
        var comment = await _commentRepository.Get(request.Id);
        if (comment == null)
            throw new NotFoundException(nameof(Comment), request.Id);

        return comment;
    }
}