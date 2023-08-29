using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Notifications.Validators;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Notifications.Handler.Commands;

public class CreateNotificationRequestHandler : IRequestHandler<CreateNotificationRequest, BaseResponseClass>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public CreateNotificationRequestHandler(INotificationRepository notificationRepository, IMapper mapper, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<BaseResponseClass> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseClass();
        var validator = new CreateNotificationRequestValidator(_notificationRepository, _userRepository);
        var validationResult = await validator.ValidateAsync(request.CreateNotificationDto);

        if(validationResult.IsValid == false) {
            response.Success = false;
            response.Message = "Creation failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            //throw new ValidationException(validationResult);
        }
        else
        {
            var notification = _mapper.Map<Notification>(request.CreateNotificationDto);
            notification = await _notificationRepository.Add(notification);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = notification.Id;

        }
        
        return response;
    }

}
