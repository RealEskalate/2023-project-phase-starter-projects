

using Application.DTO.Post;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/User/{UserId}/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator){
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetNewsFeed(int UserId ){
        var command = new GetFollowingPostRequest{Id = UserId};
        var posts = await _mediator.Send(command);
        return Ok(posts);
    }
    
    
    
    [HttpGet("{tag}")]
    public async Task<IActionResult> GetByTag( string tag)
    {
        // token getter to be implemented
        var command = new GetByTagRequest{Tag = tag};
        var posts = await _mediator.Send(command);

        return Ok(posts);
    }
    
    
    [HttpGet("{Search}")]
    public async Task<IActionResult> GetByContent( string search)
    {
        // token getter to be implemented
        var command = new GetByContenetRequest{Contenet = search};
        var posts = await _mediator.Send(command);

        return Ok(posts);
    }
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddPost([FromBody]CreatePostDto createPost, int UserId){
        createPost.UserId = UserId;
        var command = new CreatePostCommand {CreatePost = createPost};
        var postId = await _mediator.Send(command);
        return Ok(postId);
    }
    [HttpPut("{PostID}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto updatePost, int UserId){
        updatePost.UserId = UserId;
        var command = new UpdatePostCommand { UpdatedPost= updatePost};
        _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{PostID}")]
    public async Task<IActionResult> DeletePoset(int PostId){
        var command = new DeletePostCommand { Id= PostId};
        return NoContent();
    }
}


