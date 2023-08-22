using Application.Contracts.Persistance;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly Mapper _mapper;

    public DeletePostCommandHandler(IPostRepository postRepository, Mapper mapper){
        _postRepository = postRepository;
        _mapper = mapper;

    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken){
        var post = await _postRepository.Get(request.Id);
        if (post == null){
            // throw Exception("Post Not Found");
        }
        await _postRepository.Delete(post);
        return Unit.Value;
    }
}