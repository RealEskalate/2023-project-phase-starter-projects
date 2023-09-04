using Application.Common;
using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CommentReactionFeature.Handlers.Commands
{
    public class MakeCommentReactionHandler : IRequestHandler<MakeReactionOnComment, BaseResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public MakeCommentReactionHandler(IMapper mapper, IUnitOfWork unitOfWork,IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<BaseResponse<int>> Handle(MakeReactionOnComment request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exists = await _unitOfWork.CommentRepository.Exists(request.ReactionData.ReactedId);
            if (exists == false)
            {
                throw new NotFoundException("Comment is not found to make the Reactions");
            }


            var commentReaction = _mapper.Map<CommentReaction>(request.ReactionData);
            


            if (request.ReactionData.ReactionType == "like")
            {
                commentReaction.Like = true;
            }
            else
            {
                commentReaction.Dislike = true;
            }

            commentReaction.CommentId = request.ReactionData.ReactedId;



            var result = await _unitOfWork.CommentReactionRepository.MakeReaction(request.UserId, commentReaction);
            if (result == null)
            {
                throw new BadRequestException("Comment is not found");
            }


            return new BaseResponse<int>()
            {
                Success = true,
                Message = "Reaction is made successfully",
                Value = request.ReactionData.ReactedId
            };
        }
    }
}