using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.CommentFeatures.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateComment(CommentCreateCommand command)
        {
            int commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateComment(int id, CommentUpdateCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Comment Id mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _mediator.Send(new CommentDeleteCommand { Id = id });
            return NoContent();
        }

        [HttpGet("/all")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _mediator.Send(new GetAllComments());
            return Ok(comments);
        }

        [HttpGet("getOne/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _mediator.Send(new GetCommentQuery { CommentId = id });
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }


    }

    internal class GetAllComments : IRequest<object>
    {
    }
}
