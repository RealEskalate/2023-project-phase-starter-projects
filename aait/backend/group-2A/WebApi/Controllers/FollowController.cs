using Application.DTO.CommentDTO;
using Application.DTO.FollowDTO;
using Application.DTO.UserDTO;
using Application.Features.FollowFeatures.Request.Command;
using Application.Features.FollowFeatures.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

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

        [HttpGet("followers")]
        public async Task<IActionResult> GetFollower([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var userId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            var command = new GetFollowerRequest { Id = userId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
            var follower = await _mediator.Send(command);
            return ResponseHandler<List<UserDto>>.HandleResponse(follower, 200);
        }

        [HttpGet("followees")]
        public async Task<IActionResult> GetFollowee([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var userId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            var command = new GetFollowingRequest { Id = userId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
            var followee = await _mediator.Send(command);
            return ResponseHandler<List<UserDto>>.HandleResponse(followee, 200);
        }

        [HttpPost("follow/{userId:int}")]
        public async Task<IActionResult> Follow(int userId)
        {
            var command = new CreateFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader")?.Value ?? "-1"),
                FollowedId = userId
            } };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 201);
        }

        [HttpDelete("unfollow/{userId:int}")]
        public async Task<IActionResult> Unfollow(int userId)
        {
            var command = new DeleteFollowCommand { follow = new FollowDto{
                FollowerId = int.Parse(User.FindFirst("reader")?.Value ?? "-1"),
                FollowedId = userId
            } };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(result, 204);
        }

    }
}