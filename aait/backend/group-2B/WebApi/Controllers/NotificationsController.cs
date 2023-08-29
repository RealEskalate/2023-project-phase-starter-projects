using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.DTOs.Notifications;
using SocialSync.Application.Features.Notifications.Requests.Commands;
using SocialSync.Application.Features.Notifications.Requests.Queries;
using SocialSyncApplication.Features.Notifications.Requests.Commands;

namespace SocialSync.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // Create a new notification
    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody] NotificationCreateDto notificationCreateDto)
    {
        var command = new CreateNotificationCommand {NotificationCreateDto = notificationCreateDto};
        var response = await _mediator.Send(command);

        if(response.IsSuccess){
            return Ok(response.Value);
        }
        else{
            return BadRequest(response.Message);
        }
    }

    // delete a notification
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        var command = new DeleteNotificationCommand {NotificationId = id};
        var response = await _mediator.Send(command);

        if (response.IsSuccess){
            return Ok(response.Value);
        }
        else{
            return BadRequest(response.Message);
        }
    }

    // Get all notifications for a user
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllNotificationsForUser(int userId)
    {
        var notifications = new GetNotificationListRequest {UserId = userId};
        var response = await _mediator.Send(notifications);

        if (response.IsSuccess){
            return Ok(response.Value);
        }
        else{
            return BadRequest(response.Message);
        }
    }

    // Get details of a specific notification
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotificationDetails(int id)
    {
        var notificationDetail = new GetNotificationDetailRequest {Id = id};
        var response = await _mediator.Send(notificationDetail);

        if (response.IsSuccess){
            return Ok(response.Value);
        }
        else{
            return BadRequest(response.Message);
        }
    }
}

