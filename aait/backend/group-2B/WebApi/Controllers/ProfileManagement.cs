using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Users;
using Application.Features.Users.Requests.Queries;
using Application.Features.Users.Requests.Commands;
using SocialSync.Application.DTOs.Authentication;
using Application.DTOs.Common;
using SocialSync.WebApi.Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/account")]
public class ProfileManagement : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public ProfileManagement(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<ActionResult> GetAllUser()
    {
        var response = await _mediator.Send(new GetAllUserQuerieRequest());
        return Ok(response);
    }

    [HttpGet("user/{id:int}")]
    public async Task<ActionResult> GetUsers(int id)
    {
        var response = await _mediator.Send(new GetUserQuerieRequest { Id = id });
        return Ok(response);
    }

    [HttpGet("followers/{id:int}")]
    public async Task<ActionResult> GetAllFollowers(int id)
    {
        var response = await _mediator.Send(new GetFollowersQuerieRequest { Id = id });
        return Ok(response);
    }

    [HttpGet("followings/{id:int}")]
    public async Task<ActionResult> GetAllFollowings(int id)
    {
        var response = await _mediator.Send(new GetFollowingsQuerieRequest { Id = id });
        return Ok(response);
    }

    [HttpPost("follow/{followedId:int}")]
    public async Task<IActionResult> UserFollowApi(int followedId)
    {
        var userId = _userService.GetUserId();
        var followDto = new FollowUnFollowDto { FollwerId = userId, FollowedId = followedId };
        var response = await _mediator.Send(
            new FollowUserCommandRequest { FollowUnfollowDto = followDto }
        );
        return Ok(response);
    }

    [HttpPost("unfollow/{unfollowedId:int}")]
    public async Task<IActionResult> UserUnFollowApi(int unfollowedId)
    {
        var userId = _userService.GetUserId();
        var unfollowDto = new FollowUnFollowDto { FollwerId = userId, FollowedId = unfollowedId };
        var command = new UnFollowUserCommandRequest { UnfollowDto = unfollowDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPatch("update/{userId:int}")]
    public async Task<IActionResult> UpdateUserProfile(int userId, [FromBody] UserDto userDto)
    {
        var command = new UserUpdateCommandRequest { Userdto = userDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("delete/{userId:int}")]
    public async Task<IActionResult> DelateUserAccount(int userId,
        [FromBody] UserDeleteDto userDeleteDto)
    {
        var command = new UserDeleteCommandRequest { UserdeleteDto = userDeleteDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}