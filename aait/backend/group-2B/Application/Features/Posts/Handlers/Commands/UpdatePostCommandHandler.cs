using AAiT.Backend.G2B.SocialSync.Application.Contracts.Persistence;
using AAiT.Backend.G2B.SocialSync.Application.DTOs.Validators.PostDtoValidators;
using AAiT.Backend.G2B.SocialSync.Application.Exceptions;
using AAiT.Backend.G2B.SocialSync.Application.Features.PostsFeatures.Requests;
using AutoMapper;
using MediatR;

namespace AAiT.Backend.G2B.SocialSync.Application.Features.PostFeatures.Handlers;

public class UpdatePostCommandHandler : PostsRequestHandler, IRequestHandler<UpdatePostCommand, Unit>
{
    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var UpdateValidator = new UpdatePostDtoValidator(_postRepository);
        var UpdateValidationResult = UpdateValidator.Validate(request.UpdatePostDto);
        if(!UpdateValidationResult.IsValid){
            throw new InvalidPostInputException(UpdateValidationResult.Errors.ToString());
        }
        
        var post = await _postRepository.GetById(request.UpdatePostDto.Id);
        if(post != null){
            _mapper.Map(request.UpdatePostDto, post);
            await _postRepository.Update(post);
        }
        else{
            throw new InvalidPostInputException("Input id didnot match any post id.");
        }

        return Unit.Value;
        
        
       
    }
}