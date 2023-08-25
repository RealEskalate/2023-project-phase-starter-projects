using Application.DTO.FollowDTO;
using Application.DTO.UserDTO;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.FollowFeatures.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : Controller
    {
        private readonly IMediator _mediator;
        public FollowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("followers/{UserId}")]
        public async Task<ActionResult<List<UserDto>>> GetFollower( int UserId)
        {
            // token getter to be implemented
            var command = new GetFollowerRequest { Id = UserId };
            var follower = await _mediator.Send(command);

            return Ok(follower);
        }

        [HttpGet("followees/{UserId}")]
        public async Task<ActionResult<List<UserDto>>> GetFollowee(int UserId)
        {
            // token getter to be implemented
            var command = new GetFollowingRequest { Id = UserId };
            var followee = await _mediator.Send(command);

            return Ok(followee);
        }

        [HttpPost("follow/{UserId}")]
        public async Task<IActionResult> Follow(int UserId)
        {
            // token getter to be implemented
            var command = new CreateFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader").Value),
                FollowedId = UserId
            } };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("unfollow/{UserId}")]
        public async Task<IActionResult> Unfollow(int UserId)
        {
            // token getter to be implemented
            var command = new DeleteFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader").Value),
                FollowedId = UserId
            } };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}