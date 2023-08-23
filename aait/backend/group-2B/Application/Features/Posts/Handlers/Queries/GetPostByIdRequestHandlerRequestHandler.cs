using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.Application.Features.Posts.Requests.Queries;

namespace SocialSync.Application.Features.Posts.Handlers.Queries;

public class GetPostByIdRequestHandler : PostsRequestHandler, IRequestHandler<GetPostByIdRequest, GeneralPostDto>
{
    public GetPostByIdRequestHandler(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
    {
    }

    public async Task<GeneralPostDto> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetAsync(request.Id);
        return _mapper.Map<GeneralPostDto>(post);
    }
}