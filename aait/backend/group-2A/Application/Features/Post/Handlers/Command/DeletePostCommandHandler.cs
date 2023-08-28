using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var post = await _unitOfWork.postRepository.Get(request.Id);
            if (post == null) throw new NotFoundException(nameof(post), request.Id);
            if (post.UserId != request.UserId) throw new BadRequestException("You are Unauthtized to do this");
            await _unitOfWork.postRepository.Delete(post);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }
    }
}