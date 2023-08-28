using Application.DTO.Common;
using Application.Features.PostFeature.Requests.Commands;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("post-reaction")]
    [ApiController]
    public class PostReactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("likes/{id}")]
        public async Task<ActionResult<BaseResponse<List<ReactionResponseDTO>>>>  GetLikes(int id)
        {
            var result = await _mediator.Send(new GetPostLikesQuery{ PostId = id });
            return Ok(result);
        }


        [HttpGet("dislikes/{id}")]
        public async Task<ActionResult<BaseResponse<List<ReactionResponseDTO>>>> GetDislikes(int id)
        {
            var result = await _mediator.Send(new GetPostDislikesQuery { PostId = id });
            return Ok(result);
        }
        
        [HttpPost("react")]
        public async Task<ActionResult<BaseResponse<string>>> Post([FromBody] ReactionDTO reactionData)
        {
            // var user id from the context
            var result = await _mediator.Send(new PostReactionCommand{ UserId = 3, ReactionData = reactionData });
            return Ok(result);
        }
    }
}
