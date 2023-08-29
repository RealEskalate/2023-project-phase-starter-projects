using SocialSync.Application.Features.Interactions.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Comments.Requests.Commands;
using SocialSync.Application.DTOs.InteractionDTOs.CommentDTOs;
using SocialSync.Application.Features.Comments.Requests.Queries;
using SocialSync.Domain.Entities;
using SocialSync.WebApi.Services;
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
    [HttpPost("like")]
    public async Task<IActionResult> LikeUnlikePostAsync([FromBody] InteractionDto likeDto)
    {
        likeDto.Type = InteractionType.Like;
        likeDto.Body = null;
        likeDto.UserId = int.Parse(_userService.GetUserId());
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
    [HttpPost("comment")]
    public async Task<IActionResult> CommentOnPostAsync([FromBody] InteractionDto interactionDto)
    {
        interactionDto.Type = InteractionType.Comment;
        interactionDto.UserId = int.Parse(_userService.GetUserId());
        var command = new CreateCommentInteractionCommand { CreateCommentDto = interactionDto };
        var response = await _mediator.Send(command);

        if (response.IsSuccess)
        {
            return CreatedAtAction(nameof(GetCommentOfAPost), new { id = response.Value }, response);
        }
        else
        {
            return BadRequest(response.Message);
        }
    }

    [Authorize]
    [HttpPut("comment")]
    public async Task<IActionResult> UpdateCommentOfAPostAsync(
        [FromBody] UpdateCommentInteractionDto interactionDto
    )
    {
        interactionDto.UserId = int.Parse(_userService.GetUserId());
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
    [HttpDelete("comment")]
    public async Task<IActionResult> DeleteCommentOfAPost(
        [FromBody] DeleteCommentInteractionDto interactionDto
    )
    {
        interactionDto.UserId = int.Parse(_userService.GetUserId());
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