using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Domain.Entities;

namespace SocialSync.WebApi.Controllers;

[ApiController]
[Route("api/interactions")]
public class InteractionController : ControllerBase
{
    private readonly IMediator _mediator;

    public InteractionController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost("like")]
    public async Task<IActionResult> LikeUnlikePostAsync([FromBody] InteractionDto likeDto)
    {
        likeDto.Type = InteractionType.Like;
        likeDto.Body = null;
        var command = new LikeUnlikePostInteractionCommand { LikeDto = likeDto };

        var response = await _mediator.Send(command);

        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }


    [HttpPost("comment")]
    public async Task<IActionResult> CommentOnPostAsync([FromBody] InteractionDto interactionDto)
    {
        interactionDto.Type = InteractionType.Comment;
        var command = new CreateCommentInteractionCommand { CreateCommentDto = interactionDto };
        var response = await _mediator.Send(command);

        if (response.Success)
        {
            return Ok(response);
        }

        return BadRequest(response.Errors);
    }


    
    [HttpPut("comment")]
    public async Task<IActionResult> UpdateCommentOfAPostAsync(
        [FromBody] UpdateCommentInteractionDto interactionDto
    )
    {
        var command = new UpdateCommentInteractionCommand { UpdateCommentDto = interactionDto };
        var response = await _mediator.Send(command);

        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Errors);
        }
    }


    [HttpDelete("comment")]
    public async Task<IActionResult> DeleteCommentOfAPost(
        [FromBody] DeleteCommentInteractionDto interactionId
    )
    {
        var command =
            new DeleteCommentInteractionCommand { DeleteCommentInteractionDto = interactionId };
        var response = await _mediator.Send(command);
        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Errors);
        }
    }

    [HttpGet("comments/{postId}")]
    public async Task<IActionResult> GetAllCommentOfAPost(int postId)
    {
        var command = new GetAllCommentInteractionRequest { PostId = postId };
        var response = await _mediator.Send(command);
        if (response != null)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest();
        }
    }


    [HttpGet("comment/{id}")]
    public async Task<IActionResult> GetCommentOfAPost(int id)
    {
        var command = new GetInteractionRequest { Id = id };
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}