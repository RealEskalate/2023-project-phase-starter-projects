

using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetPostLikesHandler : IRequestHandler<GetPostLikesQuery, BaseResponse<List<ReactionResponseDTO>>>
    {
        private readonly IPostReactionRepository _postReaction;
        private readonly IMapper _mapper;

        public GetPostLikesHandler(IPostReactionRepository postReaction, IMapper mapper)
        {
            _postReaction = postReaction;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ReactionResponseDTO>>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var exists = await _postReaction.Exists(request.PostId);
            if (exists == false)
            {
                throw new NotFoundException( "Post is not found to get the Reactions"
                );
            }

            var result = await _postReaction.Likes(request.PostId);
            return new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "Likes are retrieved successfully",
                Value = _mapper.Map<List<ReactionResponseDTO>>(result)
            };
        }
    }
}
