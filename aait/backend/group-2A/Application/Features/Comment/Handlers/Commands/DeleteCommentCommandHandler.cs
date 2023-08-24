using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var comment = await _unitOfWork.commentRepository.Get(request.Id);

        if (comment == null)
        {
            response.Success = false;
            response.Message = "Comment Deletion Faild";
            response.Errors = new List<string> { "Comment Not found" };
        }
        else
        {
            await _unitOfWork.commentRepository.Delete(comment);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Comment Deletion Successful";
        }



        return response;
    }
}