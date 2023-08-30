using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Commands;
using SocialSync.Application.Features.Notifications.Requests.Queries;
using SocialSync.WebApi.Services.Interfaces;
using SocialSyncApplication.Features.Notifications.Requests.Commands;

namespace SocialSync.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    public NotificationsController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }
    // Create a new notification
    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody] NotificationCreateDto notificationCreateDto)
    {
        if(notificationCreateDto.NotificationType == "Follow"){
            notificationCreateDto.PostId = null;
        }
        var command = new CreateNotificationCommand {NotificationCreateDto = notificationCreateDto};
        var response = await _mediator.Send(command);

        if(response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // delete a notification
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        int authUserId = _userService.GetUserId();
        var command = new DeleteNotificationCommand {NotificationId = id};
        var response = await _mediator.Send(command);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get all notifications for a user
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllNotificationsForUser(int userId)
    {
        var notifications = new GetNotificationListRequest {UserId = userId};
        var response = await _mediator.Send(notifications);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }

    // Get details of a specific notification
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationDetails(int id)
    {
        var notificationDetail = new GetNotificationDetailRequest {Id = id};
        var response = await _mediator.Send(notificationDetail);

        if (response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }
}

