using Application.DTO.FollowDTO;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.FollowFeatures.Request.Queries;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : Controller
    {
        private readonly IMediator _mediator;
        public FollowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("followers")]
        public async Task<ActionResult<List<UserDto>>> GetFollower()
        {
            // token getter to be implemented
            var command = new GetFollowerRequest { Id = 1 };
            var follower = await _mediator.Send(command);

            return Ok(follower);
        }

        [HttpGet("followees")]
        public async Task<ActionResult<List<UserDto>>> GetFollowee()
        {
            // token getter to be implemented
            var command = new GetFollowingRequest { Id = 1 };
            var followee = await _mediator.Send(command);

            return Ok(followee);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Follow([FromBody] FollowDto follow)
        {
            // token getter to be implemented
            var command = new CreateFollowCommand { follow = follow };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Unfollow([FromBody] FollowDto unfollow)
        {
            // token getter to be implemented
            var command = new DeleteFollowCommand { follow = unfollow };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
