using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
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
        public async Task<IActionResult> UserFollowApi([FromBody] FollowUnFollowDto follow)
        {
            
            var command = new UserFollowCommand { FollowUnfollowDto= follow };

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPost("unfollow")]
        public async Task<IActionResult> UserUnFollowApi([FromBody]  FolllowUnFollowDto unFollowDto)
        {
            var command = new UserUnFollowCommand { UnfollowunFollowDto = unFollowDto };
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserDto userDto)
        {
            var command = new  UserUpdateCommand { Userdto = userDto };
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }


        [HttpDelete("Delate")]
        public async Task<IActionResult> DelateUserAccount(
            [FromBody] UserDeletDto userdleteDto
        )
        {
            var command = new DeleteCommentInteractionCommand { UserdleteDto = userdleteDto};
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

    }
}
