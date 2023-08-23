using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Features.Posts.Requests.Commands;

namespace SocialSync.Application.Features.Posts.Handlers.Commands;

public class RemovePostCommandHandler : PostsRequestHandler, IRequestHandler<RemovePostCommand, Unit>
{
    public RemovePostCommandHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {


        var post = await _postRepository.GetAsync(request.Id);
        if (post != null)
        {
            await _postRepository.DeleteAsync(post);
        }
        return Unit.Value;
    }
}