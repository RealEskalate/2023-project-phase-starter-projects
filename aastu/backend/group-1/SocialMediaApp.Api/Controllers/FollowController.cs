using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SocialMediaApp.Application.DTOs.Views;

namespace SocialMediaApp.Api.Controllers
{
[Route("api/[controller]")]
[ApiController]
[Authorize]
    public class FollowController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _contextAccessor;
    public FollowController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _contextAccessor = httpContextAccessor;
        
    }

    // GET:follow
    [HttpGet]
    public async Task<ActionResult<List<FollowDto>>> Get()
    {
        var users = await _mediator.Send(new GetFollowsRequest());
        return users;
    }

    // GET: follow/folllowing/{id}
    [HttpGet("following/")]
        public async Task<ActionResult<List<FollowDto>>> GetFollowings()
    {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var follow = await _mediator.Send(new GetFollowingRequest {userId = new Guid(Id)});
        
        return follow;
    }

    // POST: follow/followers
    [HttpGet("followers/")]
   public async Task<ActionResult<List<FollowDto>>> GetFollowers()
    {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var follow = await _mediator.Send(new GetFollowerRequest {userId = new Guid(Id)});
        
        return follow;
    }

   // POST: follow
    [HttpPost]
    public async Task<ActionResult> PostFollow([FromBody] CreateFollowView createFollow )
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            CreateFollowDto followDto = new CreateFollowDto()
            {
                CurrentUser = new Guid(Id),
                ToBeFollowed = createFollow.ToBeFollowed
            };
        var followcommand = new CreateFollowsRequest{createFollowDto = followDto};
        
        var followResponse = await _mediator.Send(followcommand);
        if (followResponse.Success == true)
        {
            var notificationDto = new CreateNotificationDto();
            var user = await _mediator.Send(new GetUserRequest { Id = followDto.CurrentUser});

            notificationDto.UserId = followDto.ToBeFollowed;
            notificationDto.Content = $"{user.Name} followed you recently";
            notificationDto.IsRead = false;

            var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
            await _mediator.Send(notificationCommand);
        }

            return Ok(followResponse);

    }
    // DELETE: follow/{id}
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> DeleteFollow(Guid id)
    {
        // authenticate the owner if he is the one asking to unfollow
        var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

        await _mediator.Send( new DeleteFollowCommandRequest{ Id = id, UserId = new Guid(userId) });
        return NoContent();
    }
    }
}