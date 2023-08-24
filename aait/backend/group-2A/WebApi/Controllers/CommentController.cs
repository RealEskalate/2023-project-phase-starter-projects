using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Comment.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // POST / Comment   
    [HttpPost]
    public async Task<ActionResult<int>> AddComment([FromBody] CreateCommentDto commentDto)
    {
        var command = new CreateCommentCommand{ CommentDto = commentDto };
        var commentId = await _mediator.Send(command);
        var response = new
        {
            Message = "Comment created successfully.",
            CommentId = commentId
        };
        return Ok(response);
    }
    
    // PUT / Comment/{commentId}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentDto updateComment)
    {
        var command = new UpdateCommentCommand { UpdateCommentDto = updateComment };
        await _mediator.Send(command);
        return NoContent();
    }
    
    // DELETE /Comment/{commmentId}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteComment(int id)
    {
        var command = new DeleteCommentCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    
    // GET /Comment/{commentId}
    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetComment(int id)
    {
        var query = new GetCommentRequest{ commentId = id };
        var comment = await _mediator.Send(query);
        return Ok(comment);
    }
    
    // GET /Comment/{postId}
    [HttpGet("{postId}")]
    public async Task<ActionResult<CommentDto>> GetCommentsByPost(int postId)
    {
        var query = new GetCommentsByPostIdRequest { PostId = postId };
        var comments = await _mediator.Send(query);
        return Ok(comments);
    }
    
    
    
}

