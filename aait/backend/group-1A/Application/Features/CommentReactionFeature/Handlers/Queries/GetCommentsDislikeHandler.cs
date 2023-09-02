using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.CommentReactionFeature.Handlers.Queries
{
    public class GetCommentsDislikeHandler : IRequestHandler<GetCommentsDislikeQuery, BaseResponse<List<ReactionResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCommentsDislikeHandler(IMapper mapper , IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<BaseResponse<List<ReactionResponseDTO>>> Handle(GetCommentsDislikeQuery request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.CommentRepository.Exists(request.CommentId);
            if (exists == false)
            {
                throw new NotFoundException( "Comment is not found to get the Reactions"
                );
            }

            var result = await _unitOfWork.CommentReactionRepository.DisLikes(request.CommentId);

            return new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "The Comments DisLikes are retrieved successfully",
                Value = _mapper.Map<List<ReactionResponseDTO>>(result)
            };
        }
    }
}