using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentReactionFeature.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Handlers.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CommentReactionFeature.Handlers.Commands
{
    public class MakeCommentReactionHandler : IRequestHandler<MakeReactionOnComment, BaseResponse<string>>
    {
        private readonly ICommentReactionRepository _commentReactionRespository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ICommentRepository _commentRepository;

        public MakeCommentReactionHandler(ICommentReactionRepository commentReactionRepository, IMapper mapper, IMediator mediator, ICommentRepository commentRepository)
        {
            _commentReactionRespository = commentReactionRepository;
            _mapper = mapper;
            _mediator = mediator;
            _commentRepository = commentRepository;
        }

        public async Task<BaseResponse<string>> Handle(MakeReactionOnComment request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exists = await _commentRepository.Exists(request.ReactionData.ReactedId);
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



            var result = await _commentReactionRespository.MakeReaction(request.UserId, commentReaction);
            if (result == null)
            {
                throw new BadRequestException("Comment is not found");
            }

            // notification
            var notificationData = new NotificationCreateDTO
            {
                Content = $"User with id : {request.UserId} reacted on Comment with id : {commentReaction.CommentId}",
                NotificationContentId = commentReaction.CommentId,
                NotificationType = "reaction",
                UserId = request.UserId
            };
            await _mediator.Send(new CreateNotification { NotificationData = notificationData });



            return new BaseResponse<string>()
            {
                Success = true,
                Message = "Reaction is made successfully"
            };
        }
    }
}