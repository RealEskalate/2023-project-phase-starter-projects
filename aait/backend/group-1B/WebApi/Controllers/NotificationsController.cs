using System.Security.Claims;
using Application.DTOs.Notifications;
using Application.Features.Notifications.Requests.Commands;
using Application.Features.Notifications.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Get user Id from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
        var request = new GetAllNotificationsRequest() { UserId = userId };
        var notifications = await _mediator.Send(request);

        return Ok(notifications);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetNotificationRequest() { Id = id };
        var notification = await _mediator.Send(request);

        return Ok(notification);
    }

    [HttpPatch("seen/{id:int}")]
    public async Task<IActionResult> MarkAsSeen(int id)
    {
        // Get user Id from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var request = new MarkNotificationAsSeenRequest()
            { UpdateDto = new UpdateNotificationDto() { UserId = userId, Id = id } };
        await _mediator.Send(request);

        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Get user Id from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var request = new DeleteNotificationRequest()
            { DeleteDto = new UpdateNotificationDto() { UserId = userId, Id = id } };
        await _mediator.Send(request);

        return NoContent();
    }

}