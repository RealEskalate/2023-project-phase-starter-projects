using Application.DTOs.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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


    [HttpPost("Follow")]
    public async Task<IActionResult> UserFollowApi([FromBody] FollowUnFollowDto followDto)
    {

        var command = new FollowUserCommandRequest { FollowUnfollowDto = followDto };

        var response = await _mediator.Send(command);

        return OK(response);
    }


    [HttpPost("unfollow")]
    public async Task<IActionResult> UserUnFollowApi([FromBody] FolllowUnFollowDto unFollowDto)
    {
        var command = new UnFollowUserCommandRequest { UnfollowunFollowDto = unFollowDto };
        var response = await _mediator.Send(command);

        return Ok(response);
    }


    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UserDto userDto)
    {
        var command = new UserUpdateCommandRequest { Userdto = userDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpDelete("Delate")]
    public async Task<IActionResult> DelateUserAccount(
        [FromBody] UserDeleteDto userDeleteDto
    )
    {
        var command = new UserDeleteCommandRequest { UserdeleteDto = userDeleteDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

}
