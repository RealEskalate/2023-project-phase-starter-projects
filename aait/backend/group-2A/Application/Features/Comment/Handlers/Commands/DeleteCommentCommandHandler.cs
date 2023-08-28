using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var comment = await _unitOfWork.commentRepository.Get(request.Id);

            if (comment == null) throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
            if (comment.UserId != request.UserId) throw new BadRequestException("You can't Do this");


            await _unitOfWork.commentRepository.Delete(comment);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");


            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);

        }
    }
}