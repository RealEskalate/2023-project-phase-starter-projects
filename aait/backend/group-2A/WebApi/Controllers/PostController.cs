

using Application.DTO.Post;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetNewsFeed( )
    {
        var command = new GetFollowingPostRequest();
        var posts = await _mediator.Send(command);

        return Ok(posts);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddPost(CreatePostDto createPost){
        var command = new CreatePostCommand {CreatePost = createPost};
        var postId = await _mediator.Send(command);
        return Ok(postId);
    }
}

