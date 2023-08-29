using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateNotificationHandler(INotificationRepository notificationRepository, IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
            _notificationRepository = notificationRepository;
            
        }
        public async Task<bool> Handle(CreateNotification request, CancellationToken cancellationToken)
        {
            var newNotification = _mapper.Map<Notification>(request.NotificationData);
            // var followers = 
            switch (request.NotificationData.NotificationType.ToLower())
            {
                case "post":
                    newNotification.Post = true;
                    var followers = await _mediator.Send(new GetFollowersQuery(){
                        Id = request.NotificationData.UserId});

                    foreach(var follower in followers.Value){
                        newNotification.UserId = follower.Id;
                        await _notificationRepository.Add(newNotification);
                    }
                    break;

                case "comment":
                    newNotification.Comment = true;
                    var post = await _mediator.Send(new GetSinglePostQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = post.Value.UserId;
                    await _notificationRepository.Add(newNotification);
                    break;

                case "follow":
                    newNotification.Follow = true;
                    await _notificationRepository.Add(newNotification);
                    break;

                case "Comment-reaction":
                    newNotification.Reaction = true;
                    var comment = await _mediator.Send(new GetSingleCommentQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = comment.Value.UserId;
                    await _notificationRepository.Add(newNotification);

                    break;

                case "Post-reaction":
                    newNotification.Reaction = true;
                    var Post = await _mediator.Send(new GetSinglePostQuery(){Id = newNotification.NotificationContentId});
                    newNotification.UserId = Post.Value.UserId;

                    await _notificationRepository.Add(newNotification);
                    break;

                default:
                    return false;
            }
            
            return true;
        }
    }
}