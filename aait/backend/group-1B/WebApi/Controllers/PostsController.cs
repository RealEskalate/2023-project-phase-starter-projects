using System.Security.Claims;
using Application.DTOs.PostLikes;
using Application.DTOs.Posts;
using Application.Features.PostLikes.Requests.Commands;
using Application.Features.PostLikes.Requests.Queries;
using Application.Features.Posts.Handlers.Commands;
using Application.Features.Posts.Requests.Commands;
using Application.Features.Posts.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _mediator.Send(new GetAllPostsRequest());
        return Ok(posts);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var request = new GetPostRequest() { Id = id };
        var post = await _mediator.Send(request);
        return Ok(post);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var request = new GetPostsByUserIdRequest() { UserId = userId };
        var posts = await _mediator.Send(request);
        return Ok(posts);
    }

    [HttpGet("search/{tagName}")]
    public async Task<IActionResult> GetByTag(string tagName)
    {
        var request = new GetPostsByTagRequest() { Tag = tagName };
        var posts = await _mediator.Send(request);
        return Ok(posts);
    }

    [HttpGet("feed")]
    public async Task<IActionResult> GetFeed()
    {
        // Get user Id from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var request = new GetPostsFromFollowingRequest() { UserId = userId };
        var posts = await _mediator.Send(request);
        return Ok(posts);
    }

    [HttpGet("{postId:int}/likes")]
    public async Task<IActionResult> GetLikes(int postId)
    {
        var request = new GetLikesByPostIdRequest() { PostId = postId };
        var likes = await _mediator.Send(request);

        return Ok(likes);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto post)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        post.UserId = userId;
        
        var request = new CreatePostRequest() { Post = post };
        var createdPost = await _mediator.Send(request);
        return Ok(createdPost);
    }
    
    [HttpPatch]
    public async Task<IActionResult> Update(UpdatePostDto post)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        post.UserId = userId;
        
        var request = new UpdatePostRequest() { Post = post };
        var updatedPost = await _mediator.Send(request);
        return Ok(updatedPost);
    }

    [HttpPatch("changeLike")]
    public async Task<IActionResult> ChangeLike(ChangeLikeDto changeLikeDto)
    {
        // Add user Id to the dto from the verified token
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        changeLikeDto.UserId = userId;
        
        var request = new ChangeLikeRequest() { ChangeLike = changeLikeDto };
        await _mediator.Send(request);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var request = new DeletePostRequest() { Id = id };
        await _mediator.Send(request);
        return NoContent();
    }
}