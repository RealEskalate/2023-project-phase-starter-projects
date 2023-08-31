using Application.DTO.CommentDTO;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Comment.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

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
        commentDto.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new CreateCommentCommand{ CommentDto = commentDto };
        var commentId = await _mediator.Send(command);
        return ResponseHandler<int>.HandleResponse(commentId, 201);

    }
    
    // PUT / Comment/{commentId}
    [HttpPut("{CommentId}")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateComment){
        updateComment.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new UpdateCommentCommand { UpdateCommentDto = updateComment };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{commentId}")]
    public async Task<IActionResult> DeleteComment(int commentId)
    {
        var command = new DeleteCommentCommand { Id = commentId , UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    [HttpGet("{commentId:int}")]
    public async Task<IActionResult> GetComment(int commentId )
    {
        var query = new GetCommentRequest{ commentId = commentId };
        var comment = await _mediator.Send(query);
        return ResponseHandler<CommentDto>.HandleResponse(comment, 200);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCommentsByPost([FromQuery]int postId,  [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
        var query = new GetCommentsByPostIdRequest
            { PostId = postId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
        var comments = await _mediator.Send(query);
        return ResponseHandler<List<CommentDto>>.HandleResponse(comments, 200);
    }
    
    
    
}

