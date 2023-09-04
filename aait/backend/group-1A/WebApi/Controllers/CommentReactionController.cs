using System.Security.Claims;
using Application.Common;
using Application.DTO.Common;
using Application.DTO.NotificationDTO;
using Application.Features.CommentReactionFeature.Requests.Commands;
using Application.Features.CommentReactionFeature.Requests.Queries;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("comment-reaction")]
    public class CommentReactionController : ControllerBase
    {
         private readonly IMediator _mediator;

        public CommentReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("likes/{id}")]
        public async Task<ActionResult<BaseResponse<List<ReactionResponseDTO>>>>  GetLikes(int id)
        {
            var result = await _mediator.Send(new GetCommentsLikeQuery{ CommentId = id });
            return Ok(result);
        }


        [HttpGet("dislikes/{id}")]
        public async Task<ActionResult<BaseResponse<List<ReactionResponseDTO>>>> GetDislikes(int id)
        {
            var result = await _mediator.Send(new GetCommentsDislikeQuery { CommentId = id });
            return Ok(result);
        }
        
        [HttpPost("react")]
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] ReactionDTO reactionData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new MakeReactionOnComment{ UserId = userId, ReactionData = reactionData });
            
            return Ok(result);
        }
    }
}