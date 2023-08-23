using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostsByUserIdRequestHandler : PostsRequestHandler, IRequestHandler<GetPostsByUserIdRequest, IReadOnlyCollection<GeneralPostDto>>
{
    public GetPostsByUserIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IReadOnlyCollection<GeneralPostDto>> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Post> postsByUserId = await _postRepository.GetPostsByUserId(request.UserId);
        return _mapper.Map<IReadOnlyList<GeneralPostDto>>(postsByUserId);
    }
}
