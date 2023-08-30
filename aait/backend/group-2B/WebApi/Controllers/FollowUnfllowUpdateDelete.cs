using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Common;
using Applicatin.Features.Users.Handlers.Commands;
using Applicatin.Features.Users.Requests.Commands;
using Application.DTOs.Users;

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
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(){
        var user = new GetUserQuerieRequestHanler();
        var response = await _mediator.Send(user);
        return Ok(response);
    }
    [HttpGet("getusers")]
    public async Task<ActionResult> GetAllUsers(int id)
    {
        var user = new GetAllUserQuerieRequestHanler{Id = id};
        var response = await _mediator.Send(user);
        return Ok(response);
    }
    [HttpGet("followers/{id}")]
    public async  Task<ActionResult> GetAllFollowers(int id){

        var followers = new GetFollowersQuerieRequestHandler { Id = id };
        var response = await _mediator.Send(followers);
        return Ok(response);
    }
    [HttpGet("followings/{id}")]
    public async Task<ActionResult> GetAllFollowings(int id)
    {

        var followers = new GetFollowingsQuerieRequestHandler { Id = id };
        var response = await _mediator.Send(followers);
        return Ok(response);
    }

    [HttpPost("Follow")]
    public async Task<IActionResult> UserFollowApi([FromBody] FollowUnFollowDto followDto)
    {

        var command = new FollowUserCommandRequest { FollowUnfollowDto = followDto };

        var response = await _mediator.Send(command);

        return Ok(response);
    }


    [HttpPost("unfollow")]
    public async Task<IActionResult> UserUnFollowApi([FromBody] FollowUnFollowDto unFollowDto)
    {
        var command = new UnFollowUserCommandRequest { UnfollowDto = unFollowDto };
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
        [FromBody] UserDeletDto userDeleteDto
    )
    {
        var command = new UserDeleteCommandRequest { UserdeleteDto = userDeleteDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

}
