using Application.DTOs.Common;
using Application.DTOs.Users;
using Application.Features.Users.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("api/FollowUnfollowUpdateDelate")]
    public class FollowUnFollowUpadateDelateController:ControllerBase
    {

        private readonly IMediator _mediator;

        public FollowUnFollowUpadateDelateController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Follow")]
        public async Task<IActionResult> FOllow([FromBody]  FollowUnFollowDto follow)
        {
            var command = new  FollowUserCommand{FollowUnfollowDto = follow};

            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HttpPost("UnFollow")]
        public async Task<IActionResult> UnFollow([FromBody] FollowUnFollowDto unfollow)
        {
            var command = new UnFollowUserCommand{ UnfollowunFollowDto= unfollow};
            var response = await _mediator.Send(command);
            return Ok(response);
            
        }


        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUserAccount( [FromBody] UserDto userDto)
        {
            var command = new UserUpdateCommand{ Userdto = userDto};
            var  response = await _mediator.Send(command);

            return Ok(response);
            
        }


        [HttpDelete("Delate")]
        public async Task<IActionResult> DelateUserAccount([FromBody] UserDeletDto user)
        {
            var command = new UserDeleteCommand{UserdleteDto = user };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }

}