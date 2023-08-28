using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostByIdRequestHandler : PostsRequestHandler, IRequestHandler<GetPostByIdRequest, PostDto>
{
    public GetPostByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<PostDto> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetAsync(request.Id);
        return _mapper.Map<PostDto>(post);
    }
}