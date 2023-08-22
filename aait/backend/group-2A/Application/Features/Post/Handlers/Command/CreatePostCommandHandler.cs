using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;
    private readonly Mapper _mapper;

    public CreatePostCommandHandler(IPostRepository postRepository, IUserRepository userRepository, Mapper mapper){
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;

    }

    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken){
        var validator = new CreatePostDtoValidator(_postRepository, _userRepository);
        var validationResult = await validator.ValidateAsync(request.CreatePost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = _mapper.Map<Domain.Entities.Post>(request.CreatePost);
        await _postRepository.Add(post);
        return post.Id;
    }
}