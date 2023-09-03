using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Contracts;
using Application.Features.CommentFeatures.Requests.Queries;
using Application.Features.FollowFeature.Requests.Queries;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Queries;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Commands
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotification, bool>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateNotificationHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<bool> Handle(CreateNotification request, CancellationToken cancellationToken)
        {
            var newNotification = _mapper.Map<Notification>(request.NotificationData);

            switch (request.NotificationData.NotificationType)
            {
                case NotificationEnum.POST:
                    newNotification.Post = true;
                    var followers = await _mediator.Send(new GetFollowersQuery(){
                        Id = request.NotificationData.UserId});

                    foreach(var follower in followers.Value){
                        newNotification.UserId = follower.Id;
                        await _unitOfWork.NotificationRepository.Add(newNotification);
                    }
                    break;

                case NotificationEnum.COMMENT:
                    newNotification.Comment = true;
                    var post = await _mediator.Send(new GetSinglePostQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = post.Value.UserId;
                    await _unitOfWork.NotificationRepository.Add(newNotification);
                    break;

                case NotificationEnum.FOLLOW:
                    newNotification.Follow = true;
                    await _unitOfWork.NotificationRepository.Add(newNotification);
                    break;

                case NotificationEnum.COMMENTREACTION:
                    newNotification.Reaction = true;
                    var comment = await _mediator.Send(new GetSingleCommentQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = comment.Value.UserId;
                    await _unitOfWork.NotificationRepository.Add(newNotification);

                    break;

                case NotificationEnum.POSTREACTION:
                    newNotification.Reaction = true;
                    var Post = await _mediator.Send(new GetSinglePostQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = Post.Value.UserId;

                    await _unitOfWork.NotificationRepository.Add(newNotification);
                    break;

                default:
                    return false;
            }
            
            return true;
        }
    }
}