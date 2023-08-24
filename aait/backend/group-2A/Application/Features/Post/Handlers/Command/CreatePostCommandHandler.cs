using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken){
        var validator = new CreatePostDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
        var validationResult = await validator.ValidateAsync(request.CreatePost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = _mapper.Map<Domain.Entities.Post>(request.CreatePost);
        await _unitOfWork.postRepository.Add(post);
        await _unitOfWork.Save();
        return post.Id;
    }
}