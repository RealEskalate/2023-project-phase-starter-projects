using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdatePostDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
        var validationResult = await validator.ValidateAsync(request.UpdatedPost);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Post Update Faild";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        var post = await _unitOfWork.postRepository.Get(request.UpdatedPost.Id);
        _mapper.Map(request.UpdatedPost, post);
        await _unitOfWork.postRepository.Update(post);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Post updated Successfuly";

        return response;
    }

}