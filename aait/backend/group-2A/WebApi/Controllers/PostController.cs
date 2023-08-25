

using Application.DTO.Post;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator){
        _mediator = mediator;
    }

    [HttpGet("User/{UserId}")]
    public async Task<IActionResult> GetUserPosts( int UserId ){
        var command = new GetUserPostRequest(){Id = UserId};
        var posts = await _mediator.Send(command);
        return Ok(posts);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] string? search, [FromQuery] string? tag)
    {

        if (!string.IsNullOrEmpty(search))
        {
            var command = new GetByContenetRequest() { Contenet = search };
            var posts = await _mediator.Send(command);
            return Ok(posts);
        }
        else if (!string.IsNullOrEmpty(tag))
        {
            var command = new GetByTagRequest { Tag = tag };
            var posts = await _mediator.Send(command);
            return Ok(posts);
        }
        else
        {
            var command = new GetFollowingPostRequest{Id = int.Parse(User.FindFirst("reader").Value)};
            var posts = await _mediator.Send(command);
            return Ok(posts);
        }
    }
    
   
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddPost([FromBody]CreatePostDto createPost){
        createPost.UserId = int.Parse(User.FindFirst("reader").Value);
        var command = new CreatePostCommand {CreatePost = createPost};
        var postId = await _mediator.Send(command);
        return Ok(postId);
    }
    
    
    
    [HttpPut("{PostId}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto updatePost, int UserId, int PostId){
        updatePost.UserId = int.Parse(User.FindFirst("reader").Value);;
        updatePost.Id = PostId;
        var command = new UpdatePostCommand { UpdatedPost= updatePost};
        await _mediator.Send(command);
        return NoContent();
    }
    
    
    [HttpDelete("{PostId}")]
    public async Task<IActionResult> DeletePoset(int PostId){
        
        var command = new DeletePostCommand { Id= PostId, UserId = int.Parse(User.FindFirst("reader").Value)};
        await _mediator.Send(command);
        return NoContent();
    }
}


