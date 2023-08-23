using AAiT.Backend.G2B.SocialSync.Application.DTOs.Validators.PostDtoValidators;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Responses;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class UpdatePostCommandHandler : PostsRequestHandler, IRequestHandler<UpdatePostCommand, BaseCommandResponse>
{
    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<BaseCommandResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var UpdateValidator = new UpdatePostDtoValidator(_postRepository);
        var UpdateValidationResult = UpdateValidator.Validate(request.UpdatePostDto);
        var response = new BaseCommandResponse();
        if (!UpdateValidationResult.IsValid)
        {

            response.Success = false;
            response.Message = "Update was not successful.";
            response.Errors = UpdateValidationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }

        var post = await _postRepository.GetAsync(request.UpdatePostDto.Id);
        _mapper.Map(request.UpdatePostDto, post);
        await _postRepository.UpdateAsync(post);

        response.Success = true;
        response.Message = "Update was successful.";
        response.Id = post.Id;

        return response;



    }
}