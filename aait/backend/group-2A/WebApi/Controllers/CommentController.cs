using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Comment.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
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
    public async Task<ActionResult<int>> AddComment([FromBody] CreateCommentDto commentDto){
        commentDto.UserId = int.Parse(User.FindFirst("reader").Value);
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
    [HttpPut("{CommentId}")]
    public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentDto updateComment){
        updateComment.UserId = int.Parse(User.FindFirst("reader").Value);
        var command = new UpdateCommentCommand { UpdateCommentDto = updateComment };
        await _mediator.Send(command);
        return NoContent();
    }
    
    // DELETE /Comment/{commmentId}
    [HttpDelete("{CommentId}")]
    public async Task<ActionResult> DeleteComment(int CommentId)
    {
        var command = new DeleteCommentCommand { Id = CommentId , UserId = int.Parse(User.FindFirst("reader").Value)};
        await _mediator.Send(command);
        return NoContent();
    }
    
    // GET /Comment/{commentId}
    [HttpGet("{CommentId}")]
    public async Task<ActionResult<CommentDto>> GetComment(int CommentId)
    {
        var query = new GetCommentRequest{ commentId = CommentId };
        var comment = await _mediator.Send(query);
        return Ok(comment);
    }
    
    // GET /Comment/{postId}
    [HttpGet]
    public async Task<ActionResult<CommentDto>> GetCommentsByPost([FromQuery]int PostId)
    {
        var query = new GetCommentsByPostIdRequest { PostId = PostId };
        var comments = await _mediator.Send(query);
        return Ok(comments);
    }
    
    
    
}

