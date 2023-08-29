using Microsoft.AspNetCore.Mvc;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SocialMediaApp.Application.DTOs.Views;

namespace SocialMediaApp.Api.Controllers
{
[Route("api/[controller]")]
[ApiController]
[Authorize]
    public class UsersController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _contextAccessor;
    public UsersController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _contextAccessor = httpContextAccessor;
        
    }

    // GET: api/items
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<UserDto>>> Get()
    {
        var users = await _mediator.Send(new GetUsersRequest());
        return users;
    }

    // GET: api/items/{id}
    [HttpGet]
    public async Task<ActionResult<UserDto>> GetUserById()
    {
        var userId = new Guid(_contextAccessor.HttpContext!.User.FindFirstValue("uid"));

        var user = await _mediator.Send(new GetUserRequest { Id = userId });
        var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = userId });
        var follows=  await _mediator.Send(new GetFollowingRequest { userId = userId });
        var notifications = await _mediator.Send(new GetNotificationsRequest { UserId = userId });
        if (user != null)
        {
            user.Post = posts;
            user.Followers = follows;
            user.Notifications = notifications;

        }



        return user;
    }
    //Get:user/name
    [HttpGet("search")]
    public async Task<ActionResult<List<UserDto>>> GetByNameAsync(string name)
    {
        var users = await _mediator.Send(new GetUsersByNameRequest{Name = name});
        return users;
    }
    

    // PUT: api/items/{id}
    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] RegisterUserView user  )
    {
        var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
        UpdateUserDto updateUser = new UpdateUserDto()
        {
            Id = new Guid(userId),
            Bio = user.Bio,
            email = user.email,
            Name = user.Name,
        };
        var NewUser = new UpdateUserCommandRequest{UpdateUserDto = updateUser};
        await _mediator.Send(NewUser);

        return NoContent();
    }

    // DELETE: api/items/{id}
    [HttpDelete]
    public async Task<ActionResult> DeleteUser()
    {
        var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
        await _mediator.Send( new DeleteUserCommandRequest{ Id = new Guid(userId) });
        return NoContent();
    }
}
}
