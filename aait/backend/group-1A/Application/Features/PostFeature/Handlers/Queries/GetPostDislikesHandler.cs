using Application.Contracts;
using Application.DTO.Common;
using Application.Features.PostFeature.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetPostDislikesHandler : IRequestHandler<GetPostDislikesQuery, List<ReactionResponseDTO>>
    {
        private readonly IPostReaction _postReaction;
        private readonly IMapper _mapper;

        public GetPostDislikesHandler(IPostReaction postReaction, IMapper mapper)
        {
            _postReaction = postReaction;
            _mapper = mapper;
        }

        public async Task<List<ReactionResponseDTO>> Handle(GetPostDislikesQuery request, CancellationToken cancellationToken)
        {
            if (request.PostId <= 0)
            {
                throw new Exception();
            }

            var result = await _postReaction.DisLikes(request.PostId);
            return _mapper.Map<List<ReactionResponseDTO>>(result);

        }
    }
}
