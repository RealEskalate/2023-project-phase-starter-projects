using Application.Features.Like.Request.Commands;
using Application.Features.Like.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.Like;

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
        public async Task<IActionResult> LikePost(LikedDto likeDto)
        {
            var command = new CreateLikeCommand { Like = likeDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("UnlikePost")]
        public async Task<IActionResult> UnlikePost(int id)
        {
            var command = new DeleteLikeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("IsLiked")]
        public async Task<IActionResult> GetIsLiked([FromQuery] GetIsLikedDto getIsLikedDto)
        {
            var query = new GetIsLikedQuery { GetIsLikedDto = getIsLikedDto };
            bool isLiked = await _mediator.Send(query);
            return Ok(isLiked);
        }


        [HttpGet("PostLikes/{id}")]
        public async Task<IActionResult> GetPostLikes(int id)
        {
            var query = new GetPostLikesQuery { Id = id };
            List<LikedDto> likes = await _mediator.Send(query);
            return Ok(likes);
        }
    }
}