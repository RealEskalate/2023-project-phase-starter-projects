

using Application.Contracts;
using Application.DTO.Common;
using Application.Features.PostFeature.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetPostLikesHandler : IRequestHandler<GetPostLikesQuery, List<ReactionResponseDTO>>
    {
        private readonly IPostReactionRepository _postReaction;
        private readonly IMapper _mapper;

        public GetPostLikesHandler(IPostReactionRepository postReaction, IMapper mapper)
        {
            _postReaction = postReaction;
            _mapper = mapper;
        }

        public async Task<List<ReactionResponseDTO>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            if (request.PostId <= 0)
            {
                throw new Exception();
            }

            var result = await _postReaction.Likes(request.PostId);
            return _mapper.Map<List<ReactionResponseDTO>>(result);
        }
    }
}
