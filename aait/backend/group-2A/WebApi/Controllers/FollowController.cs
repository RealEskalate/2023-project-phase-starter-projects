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
        public async Task<IActionResult> GetFollower( int UserId)
        {
            // token getter to be implemented
            var command = new GetFollowerRequest { Id = UserId };
            var follower = await _mediator.Send(command);

            return ResponseHandler<List<UserDto>>.HandleResponse(follower, 200);
        }

        [HttpGet("followees/{UserId}")]
        public async Task<IActionResult> GetFollowee(int UserId)
        {
            // token getter to be implemented
            var command = new GetFollowingRequest { Id = UserId };
            var followee = await _mediator.Send(command);

            return ResponseHandler<List<UserDto>>.HandleResponse(followee, 200);
        }

        [HttpPost("follow/{UserId}")]
        public async Task<IActionResult> Follow(int UserId)
        {
            // token getter to be implemented
            var command = new CreateFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader").Value),
                FollowedId = UserId
            } };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 201);
        }

        [HttpDelete("unfollow/{UserId}")]
        public async Task<IActionResult> Unfollow(int UserId)
        {
            // token getter to be implemented
            var command = new DeleteFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader").Value),
                FollowedId = UserId
            } };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }

    }
}