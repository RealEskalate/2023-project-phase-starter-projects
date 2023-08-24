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

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetFollower()
        {
            // token getter to be implemented
            var command = new GetFollowerRequest { Id = 1 };
            var follower = await _mediator.Send(command);

            return Ok(follower);
        }        
        
        [HttpGet]
        public async Task<IActionResult> GetFollowee()
        {
            // token getter to be implemented
            var command = new GetFollowingRequest { Id = 1 };
            var followee = await _mediator.Send(command);

            return Ok(followee);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Follow(FollowDto follow)
        {
            // token getter to be implemented
            var command = new CreateFollowCommand { follow = follow };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{followeeID}")]
        public async Task<IActionResult> Unfollow(FollowDto followeeID)
        {
            // token getter to be implemented
            var command = new DeleteFollowCommand { follow = followeeID };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
