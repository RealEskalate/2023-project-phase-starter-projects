using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Domain;
using System.Security.Claims;

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        public NotificationController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }
        // GET: api/<NotificationController>
        [HttpGet]
        public async Task<ActionResult<List<NotificationDto>>> Get()
        {
            var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var query = new GetNotificationsRequest { UserId = new Guid(userId) };
            var notifications = await _mediator.Send(query);
            return Ok(notifications);
        }

        // GET api/<NotificationController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<NotificationDto>> Get(Guid id)
        {
            var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var query = new GetNotificationDetailsRequest { UserId = new Guid(userId), NotificationId = id };
            var notificaiton = await _mediator.Send(query);
            return Ok(notificaiton);
        }


        // DELETE api/<NotificationController>/5
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var command = new DeleteNotificationRequest { UserId = new Guid(userId),NotificationId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
