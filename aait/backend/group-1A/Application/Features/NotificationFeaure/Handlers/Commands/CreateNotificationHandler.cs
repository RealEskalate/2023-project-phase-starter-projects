using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.NotificationFeaure.Requests.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.NotificationFeaure.Handlers.Commands
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotification, bool>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public CreateNotificationHandler(INotificationRepository notificationRepository, IMapper mapper)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            
        }
        public async Task<bool> Handle(CreateNotification request, CancellationToken cancellationToken)
        {
            var newNotification = _mapper.Map<Notification>(request.NotificationData);
            switch (request.NotificationData.NotificationType.ToLower())
            {
                case "post":
                    newNotification.Post = true;
                    break;
                case "comment":
                    newNotification.Comment = true;
                    break;
                case "follow":
                    newNotification.Follow = true;
                    break;
                case "reaction":
                    newNotification.Reaction = true;
                    break;
                default:
                    return false;
            }
        
            var result =  await _notificationRepository.Add(newNotification);
            
            return result != null;
        }
    }
}