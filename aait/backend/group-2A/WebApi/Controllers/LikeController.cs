using Application.Features.Like.Request.Commands;
using Application.Features.Like.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("LikePost")]
        public async Task<IActionResult> LikePost(CreateLikeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("UnlikePost")]
        public async Task<IActionResult> UnlikePost(DeleteLikeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("IsLiked")]
        public async Task<IActionResult> GetIsLiked([FromBody] GetIsLikedQuery query)
        {
            bool isLiked = await _mediator.Send(query);
            return Ok(isLiked);
        }

        [HttpGet("PostLikes/{id}")]
        public async Task<IActionResult> GetPostLikes(int id)
        {
            GetPostLikesQuery query = new GetPostLikesQuery { Id = id };
            List<UserDto> likedUsers = await _mediator.Send(query);
            return Ok(likedUsers);
        }
    }
}