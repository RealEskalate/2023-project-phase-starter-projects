using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Requests.Queries;
using Application.Features.PostFeature.Handlers.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.CommentReactionFeature.Handlers.Queries
{
    public class GetCommentsLikeHandler : IRequestHandler<GetCommentsLikeQuery, BaseResponse<List<ReactionResponseDTO>>>
    {
        private readonly ICommentReactionRepository _commentReaction;
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentsLikeHandler(ICommentReactionRepository commentReaction, IMapper mapper, ICommentRepository commentRepository)
        {
            _commentReaction = commentReaction;
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<BaseResponse<List<ReactionResponseDTO>>> Handle(GetCommentsLikeQuery request, CancellationToken cancellationToken)
        {
            var exists = await _commentRepository.Exists(request.CommentId);
            if (exists == false)
            {
                throw new NotFoundException( "Comment is not found to get the Reactions"
                );
            }

            var result = await _commentReaction.Likes(request.CommentId);

            return new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "The Comments Likes are retrieved successfully",
                Value = _mapper.Map<List<ReactionResponseDTO>>(result)
            };
        }
    }
}