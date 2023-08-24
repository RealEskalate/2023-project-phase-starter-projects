using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken){
        var response = new BaseCommandResponse();
        var validator = new CreatePostDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
        var validationResult = await validator.ValidateAsync(request.CreatePost);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Post Creation Failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        var post = _mapper.Map<Domain.Entities.Post>(request.CreatePost);
        await _unitOfWork.postRepository.Add(post);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Post Creation Successful";
        response.Id = post.Id;

        return response;
    }
}