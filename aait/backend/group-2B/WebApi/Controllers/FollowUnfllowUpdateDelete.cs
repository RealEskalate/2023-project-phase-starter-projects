using MediatR;
using Microsoft.AspNetCore.Mvc;

using Application.DTOs.Users;
using Application.Features.Users.Requests.Queries;
using Application.Features.Users.Requests.Commands;
using SocialSync.Application.DTOs.Authentication;
using Application.DTOs.Common;

namespace WebApi.Controllers;

[ApiController]
[Route("api/ProfileMangment")]
public class FollowUnfllowUpdateDelete : ControllerBase
{
    private readonly IMediator _mediator;

    public FollowUnfllowUpdateDelete(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("users:int")]
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

    [HttpPost("follow")]
    public async Task<IActionResult> UserFollowApi([FromBody] FollowUnFollowDto followDto)
    {
        var response = await _mediator.Send(
            new FollowUserCommandRequest { FollowUnfollowDto = followDto }
        );

        return Ok(response);
    }

    [HttpPost("unfollow")]
    public async Task<IActionResult> UserUnFollowApi([FromBody] FollowUnFollowDto unFollowDto)
    {
        var command = new UnFollowUserCommandRequest { UnfollowDto = unFollowDto };
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UserDto userDto)
    {
        var command = new UserUpdateCommandRequest { Userdto = userDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DelateUserAccount([FromBody] UserDeleteDto userDeleteDto)
    {
        var command = new UserDeleteCommandRequest { UserdeleteDto = userDeleteDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
