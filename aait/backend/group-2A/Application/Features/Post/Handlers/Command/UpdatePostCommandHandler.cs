using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    private readonly Mapper _mapper;

    public UpdatePostCommandHandler(IPostRepository postRepository, IUserRepository userRepository ,Mapper mapper){
        _postRepository = postRepository;
        _userRepository = userRepository;
        _mapper = mapper;

    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken){
        var validator = new UpdatePostDtoValidator(_postRepository, _userRepository);
        var validationResult = await validator.ValidateAsync(request.UpdatedPost);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        var post = await _postRepository.Get(request.UpdatedPost.Id);
        _mapper.Map(request.UpdatedPost, post);
        await _postRepository.Update(post);
        return Unit.Value;
    }
    
}