using Application.Contracts.Persistance;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken){
        var post = await _unitOfWork.postRepository.Get(request.Id);
        if (post == null){
            // throw Exception("Post Not Found");
        }
        await _unitOfWork.postRepository.Delete(post);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}