using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Handler.Queries;

public class GetPostsRequestHandler : IRequestHandler<GetPostsRequestByUser, List<PostDto>>
{   
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper; 
    public GetPostsRequestHandler(IPostRepository postRepositiory, IMapper mapper)
    {
        _postRepository = postRepositiory;
        _mapper = mapper;

            
    }
    public async Task<List<PostDto>> Handle(GetPostsRequestByUser request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPosts(request.UserId);
        
        return _mapper.Map<List<PostDto>>(post);
    }
}
