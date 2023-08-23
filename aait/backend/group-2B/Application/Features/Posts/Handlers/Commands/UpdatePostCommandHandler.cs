using AAiT.Backend.G2B.SocialSync.Application.DTOs.Validators.PostDtoValidators;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler : PostsRequestHandler, IRequestHandler<UpdatePostCommand, Unit>
{
    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var UpdateValidator = new UpdatePostDtoValidator(_postRepository);
        var UpdateValidationResult = UpdateValidator.Validate(request.UpdatePostDto);
        // if(!UpdateValidationResult.IsValid){
        // }
        
        var post = await _postRepository.GetAsync(request.UpdatePostDto.Id);
        _mapper.Map(request.UpdatePostDto, post);
        await _postRepository.UpdateAsync(post);

        return Unit.Value;
        
        
       
    }
}