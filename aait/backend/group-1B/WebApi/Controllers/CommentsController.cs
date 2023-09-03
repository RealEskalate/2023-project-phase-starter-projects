using System.Security.Claims;
using Application.DTOs.Comments;
using Application.Features.Comments.Requests.Commands;
using Application.Features.Comments.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/post/{postId:int}")]
    public async Task<IActionResult> GetByPost(int postId)
    {
        var request = new GetCommentsByPostIdRequest() { PostId = postId};
        var comments = await _mediator.Send(request);

        return Ok(comments);
    }
    
    [HttpGet("/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetCommentRequest() { Id = id};
        var comment = await _mediator.Send(request);

        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCommentDto commentDto)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        commentDto.UserId = userId;
        
        var request = new CreateCommentRequest() { Comment = commentDto };
        var comment = await _mediator.Send(request);

        return Ok(comment);
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateCommentDto commentDto)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        commentDto.UserId = userId;
        
        var request = new UpdateCommentRequest() { Comment = commentDto };
        var comment = await _mediator.Send(request);
        return Ok(comment);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeleteCommentRequest() { Id = id };
        await _mediator.Send(request);

        return NoContent();
    }
}

