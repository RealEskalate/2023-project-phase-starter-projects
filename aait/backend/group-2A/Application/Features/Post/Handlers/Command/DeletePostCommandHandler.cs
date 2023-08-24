using Application.Contracts.Persistance;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeletePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var post = await _unitOfWork.postRepository.Get(request.Id);
        if (post == null)
        {
            response.Success = false;
            response.Message = "Post Delete Failed";
            response.Errors = new List<string> { "Post not created" };
        }
        await _unitOfWork.postRepository.Delete(post);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Post Deleted";
        return response;
    }
}