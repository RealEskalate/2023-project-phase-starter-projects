using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Common.Responses;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class RemovePostCommandHandler : PostsRequestHandler, IRequestHandler<RemovePostCommand, BaseCommandResponse>
{
    public RemovePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BaseCommandResponse> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();


        var post = await _postRepository.GetAsync(request.Id);
        if (post != null)
        {
            request.Id = post.Id;
            response.Success = true;
            response.Message = "Post Deletion Successful";
            await _postRepository.DeleteAsync(post);
        }
        else
        {
            response.Success = false;
            response.Message = "Post Deletion Failed";
            response.Errors.Add("Post id is not found");
        }
        return response;
    }
}