using System.Security.Claims;
using Application.Common;
using Application.DTO.CommentDTO.DTO;
using Application.DTO.NotificationDTO;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.CommentFeatures.Requests.Queries;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-post-Id/{id}")]
        public async Task<ActionResult<BaseResponse<List<CommentResponseDTO>>>> GetByPost(int id)
        {       
            var result = await _mediator.Send(new GetCommentsForPostQuery { PostId = id});
            return Ok(result);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CommentResponseDTO>>> GetByID(int id)
        {
            var result = await _mediator.Send(new GetSingleCommentQuery { Id = id });
            return Ok(result);
            
        }


        [HttpPost]
        public async Task<ActionResult<BaseResponse<CommentResponseDTO>>> Post([FromBody] CommentCreateDTO newCommentData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new CommentCreateCommand{ NewCommentData = newCommentData, userId = userId });
            
            return Ok(result);
            
        }

        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<CommentResponseDTO>>> Put(int id, [FromBody] CommentUpdateDTO UpdateCommentData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateCommentCommand { Id = id, CommentData = UpdateCommentData , userId = userId });
            return Ok(result);
            
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<int>>> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new CommentDeleteCommand { userId = userId, Id = id });     
            return Ok(result);
            
        }

    }
}