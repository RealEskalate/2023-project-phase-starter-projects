using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Domain.Entities;
using SocialSync.WebApi.Services.Interfaces;

namespace SocialSync.WebApi.Controllers;

[ApiController]
[Route("api/interactions")]
public class InteractionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public InteractionController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [Authorize]
    [HttpPost("{postId}/like")]
    public async Task<IActionResult> LikeUnlikePostAsync(int postId)
    {
        InteractionDto likeDto = new InteractionDto();
        likeDto.PostId = postId;
        likeDto.Type = InteractionType.Like;
        likeDto.Body = null;
        likeDto.UserId = _userService.GetUserId();
        var command = new LikeUnlikePostInteractionCommand { LikeDto = likeDto };

        var response = await _mediator.Send(command);

        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }

    [Authorize]
    [HttpPost("{postId}/comment")]
    public async Task<IActionResult> CommentOnPostAsync(int postId, [FromBody] String content)
    {
        InteractionDto interactionDto = new InteractionDto();
        interactionDto.Body = content;
        interactionDto.PostId = postId;
        interactionDto.Type = InteractionType.Comment;
        interactionDto.UserId = _userService.GetUserId();
        var command = new CreateCommentInteractionCommand { CreateCommentDto = interactionDto };
        var response = await _mediator.Send(command);

        if (response.IsSuccess)
        {
            return CreatedAtAction(nameof(GetCommentOfAPost), new { id = response.Value },
                response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }

    [Authorize]
    [HttpPut("comment/{commentId}")]
    public async Task<IActionResult> UpdateCommentOfAPostAsync(int commentId,
        [FromBody] UpdateCommentInteractionDto interactionDto
    )
    {
        interactionDto.Id = commentId;
        interactionDto.UserId = _userService.GetUserId();
        var command = new UpdateCommentInteractionCommand { UpdateCommentDto = interactionDto };
        var response = await _mediator.Send(command);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }

    [Authorize]
    [HttpDelete("comment/{commentId}")]
    public async Task<IActionResult> DeleteCommentOfAPost(int commentId,
        [FromBody] DeleteCommentInteractionDto interactionDto
    )
    {
        interactionDto.Id = commentId;
        interactionDto.UserId = _userService.GetUserId();
        var command =
            new DeleteCommentInteractionCommand { DeleteCommentInteractionDto = interactionDto };
        var response = await _mediator.Send(command);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }

    [HttpGet("comments/{postId}")]
    public async Task<IActionResult> GetAllCommentOfAPost(int postId)
    {
        var command = new GetAllCommentInteractionRequest { PostId = postId };
        var response = await _mediator.Send(command);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }


    [HttpGet("comment/{id}")]
    public async Task<IActionResult> GetCommentOfAPost(int id)
    {
        var command = new GetInteractionRequest { Id = id };
        var response = await _mediator.Send(command);
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }
}