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
    public async Task<IActionResult> AddComment([FromBody] CreateCommentDto commentDto){
        commentDto.UserId = int.Parse(User.FindFirst("reader").Value);
        var command = new CreateCommentCommand{ CommentDto = commentDto };
        var commentId = await _mediator.Send(command);
        return ResponseHandler<int>.HandleResponse(commentId, 201);

    }
    
    // PUT / Comment/{commentId}
    [HttpPut("{CommentId}")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateComment){
        updateComment.UserId = int.Parse(User.FindFirst("reader").Value);
        var command = new UpdateCommentCommand { UpdateCommentDto = updateComment };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    // DELETE /Comment/{commmentId}
    [HttpDelete("{CommentId}")]
    public async Task<IActionResult> DeleteComment(int CommentId)
    {
        var command = new DeleteCommentCommand { Id = CommentId , UserId = int.Parse(User.FindFirst("reader").Value)};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    // GET /Comment/{commentId}
    [HttpGet("{CommentId}")]
    public async Task<IActionResult> GetComment(int CommentId)
    {
        var query = new GetCommentRequest{ commentId = CommentId };
        var comment = await _mediator.Send(query);
        return ResponseHandler<CommentDto>.HandleResponse(comment, 200);
    }
    
    // GET /Comment/{postId}
    [HttpGet]
    public async Task<IActionResult> GetCommentsByPost([FromQuery]int PostId)
    {
        var query = new GetCommentsByPostIdRequest { PostId = PostId };
        var comments = await _mediator.Send(query);
        return ResponseHandler<List<CommentDto>>.HandleResponse(comments, 200);
    }
    
    
    
}

