

using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetPostLikesHandler : IRequestHandler<GetPostLikesQuery, BaseResponse<BaseResponse<List<ReactionResponseDTO>>>>
    {
        private readonly IPostReactionRepository _postReaction;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostLikesHandler(IPostReactionRepository postReaction, IMapper mapper, IPostRepository postRepository)
        {
            _postReaction = postReaction;
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public async Task<BaseResponse<BaseResponse<List<ReactionResponseDTO>>>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var exists = await _postRepository.Exists(request.PostId);
            if (exists == false)
            {
                throw new NotFoundException( "Post is not found to get the Reactions");
            var exists = await _postReaction.Exists(request.PostId);
            if (exists == false)
            {
                throw new NotFoundNotFoundException( "Post is not found to get the Reactions" "Post is not found to get the Reactions"
                );
            }

            var result = await _postReaction.Likes(request.PostId);
            return new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "Likes are retrieved successfully",
                Value = new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "Likes are retrieved successfully",
                Value = _mapper.Map<List<ReactionResponseDTO>>(result)
            }
            };
        }
    }
}
