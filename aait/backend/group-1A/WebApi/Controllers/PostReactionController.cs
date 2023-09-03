using System.Security.Claims;
using Application.Common;
using Application.DTO.Common;
using Application.DTO.NotificationDTO;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
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
        public async Task<ActionResult<BaseResponse<int>>> Post([FromBody] ReactionDTO reactionData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new PostReactionCommand{ UserId = userId, ReactionData = reactionData });
            
            return Ok(result);
        }
    }
}
