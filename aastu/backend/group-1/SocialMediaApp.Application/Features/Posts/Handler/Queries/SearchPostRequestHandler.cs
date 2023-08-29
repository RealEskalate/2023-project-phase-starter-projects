using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Posts.Handler.Queries
{
    public class SearchPostRequestHandler : IRequestHandler<SearchPostRequest, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public SearchPostRequestHandler(IPostRepository postRepositiory, IMapper mapper)
        {
            _postRepository = postRepositiory;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> Handle(SearchPostRequest request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.SearchPosts(request.query) ?? throw new NotFoundException("${request.query}", request.query);
            return _mapper.Map<List<PostDto>>(posts);
        }
    }
}