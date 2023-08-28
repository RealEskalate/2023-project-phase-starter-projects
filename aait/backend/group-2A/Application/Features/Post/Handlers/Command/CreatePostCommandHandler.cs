using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreatePostDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.CreatePost);
            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var post = _mapper.Map<Domain.Entities.Post>(request.CreatePost);
            await _unitOfWork.postRepository.Add(post);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");


            return BaseCommandResponse<int>.SuccessHandler(post.Id);
        }catch (Exception ex)
        {
            return BaseCommandResponse<int>.FailureHandler(ex);
        }

        
    }
}