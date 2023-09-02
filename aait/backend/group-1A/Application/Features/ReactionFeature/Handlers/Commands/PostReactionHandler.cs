using Application.Common;
using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Commands
{
    public class PostReactionHandler : IRequestHandler<PostReactionCommand, BaseResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public PostReactionHandler(IMediator mediator,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }        
        public async Task<BaseResponse<int>> Handle(PostReactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new ReactionValidator();
            var validationResult = await validator.ValidateAsync(request.ReactionData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var exists = await _unitOfWork.PostRepository.Exists(request.ReactionData.ReactedId);
            if (exists == false)
            {
                throw new NotFoundException("Post is not found to make the Reactions");
            }


            var postReaction = _mapper.Map<PostReaction>(request.ReactionData);
            


            if (request.ReactionData.ReactionType == "like")
            {
                postReaction.Like = true;
            }
            else
            {
                postReaction.Dislike = true;
            }

            postReaction.PostId = request.ReactionData.ReactedId;



            var result = await _unitOfWork.PostReactionRepository.MakeReaction(request.UserId, postReaction);
            if (result == null)
            {
                throw new BadRequestException("Post is not found");
            }



            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
                    {
                        Content = $"User with {request.UserId} reacted on your post",
                        NotificationContentId = request.ReactionData.ReactedId,
                        NotificationType = NotificationEnum.POST,
                        UserId = request.UserId}});

                        
            return new BaseResponse<int>()
            {
                Success = true,
                Message = "Reaction is made successfully",
                Value = request.ReactionData.ReactedId
            };
        }
    }
}
