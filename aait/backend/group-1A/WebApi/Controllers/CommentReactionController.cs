using System.Threading.Tasks;
using Application.Features.CommentReactionFeatures.Requests.Commands;
using Application.Features.CommentReactionFeatures.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CommentReactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateCommentReaction(CommentReactionCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCommentReaction(int id, CommentReactionUpdateCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCommentReaction(int id)
        {
            var command = new CommentReactionDeleteCommand { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCommentReaction(int id)
        {
            var query = new GetCommentReactionQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
