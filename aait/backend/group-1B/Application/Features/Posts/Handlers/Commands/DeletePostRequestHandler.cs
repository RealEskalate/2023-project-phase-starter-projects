using Application.Common.Exceptions;
using Application.Contracts.Persistence;
using Application.Features.Posts.Requests.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class DeletePostRequestHandler : IRequestHandler<DeletePostRequest, Unit>
{
    private readonly IPostRepository _postRepository;

    public DeletePostRequestHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Unit> Handle(DeletePostRequest request, CancellationToken token)
    {
        var post = await _postRepository.Get(request.Id);

        if (post == null)
            throw new NotFoundException(nameof(Post), request.Id);
        
        await _postRepository.Delete(post);

        return Unit.Value;
    }
}