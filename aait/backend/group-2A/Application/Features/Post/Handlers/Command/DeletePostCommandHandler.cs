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
        
        if (post == null || post.UserId != request.UserId){
            throw new Exception("You Don't Have Access");
        }
        await _unitOfWork.postRepository.Delete(post);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}