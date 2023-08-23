using System.Threading.Tasks;
using Application.Features.CommentReactionFeatures.Requests.Commands;
using Application.Features.CommentReactionFeatures.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentReactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<IActionResult>? CreateCommentReaction(CommentReactionCreateCommand command)
        {

            return null;
        }

    }
}
