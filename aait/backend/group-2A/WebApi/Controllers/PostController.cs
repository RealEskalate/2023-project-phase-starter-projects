

using Application.DTO.Post;
using Application.Features.Post.Request.Commands;
using Application.Features.Post.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

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

    [HttpGet("User/{userId:int}")]
    public async Task<IActionResult> GetUserPosts(int userId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {
        var command = new GetUserPostRequest() { Id = userId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
        var posts = await _mediator.Send(command);
        return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    }

    
    
    [HttpGet]
    public async Task<IActionResult> GetPosts([FromQuery] string? search, [FromQuery] string? tag,  [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
    {

        if (!string.IsNullOrEmpty(search))
        {
            var command = new GetByContenetRequest() { Contenet = search, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
            var posts = await _mediator.Send(command);
            return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
        }
        else if (!string.IsNullOrEmpty(tag))
        {
            var command = new GetByTagRequest { Tag = tag, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
            var posts = await _mediator.Send(command);
            return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
        }
        else
        {
            var command = new GetFollowingPostRequest{Id = int.Parse(User.FindFirst("reader")?.Value ?? "-1"), PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10};
            var posts = await _mediator.Send(command);
            return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
        }
    }
    
   
    
    [HttpPost("Add")]
    public async Task<IActionResult> AddPost([FromBody]CreatePostDto createPost){
        createPost.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        var command = new CreatePostCommand {CreatePost = createPost};
        var postId = await _mediator.Send(command);
        return ResponseHandler<int>.HandleResponse(postId, 201);
    }

    [HttpPut("{postId:int}")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto updatePost, int postId){
        updatePost.UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
        updatePost.Id = postId;
        var command = new UpdatePostCommand { UpdatedPost= updatePost};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
    
    [HttpDelete("{postId:int}")]
    public async Task<IActionResult> DeletePost(int postId){
        var command = new DeletePostCommand { Id= postId, UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1")};
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }
}