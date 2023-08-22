using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetSinglePostHandler : IRequestHandler<GetSinglePostQuery, PostResponseDTO>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetSinglePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<PostResponseDTO> Handle(GetSinglePostQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var result = await _postRepository.Get(request.Id);

            if (result == null)
            {
                throw new Exception();
            }

            var post = _mapper.Map<PostResponseDTO>(result);
            post.Like = result.PostReactions.Where(x => x.Like == true).Count();
            post.Dislike = result.PostReactions.Where(x => x.Like == false).Count();
            return post;
        }
    }
}
