using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Requests.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetAllPostHandler : IRequestHandler<GetAllPostsQuery, List<PostResponseDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<List<PostResponseDTO>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var result = await _postRepository.GetAll();

            return _mapper.Map<List<PostResponseDTO>>(result);
        }
    }
}
