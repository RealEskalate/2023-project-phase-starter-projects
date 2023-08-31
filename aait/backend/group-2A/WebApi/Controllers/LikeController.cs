using Application.DTO.Like;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Application.Features.Like.Request.Commands;
using Application.Features.Like.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Middleware;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LikeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
  
    [HttpPost("{postId:int}")]
    public async Task<IActionResult> AddLike( int postId)
    {
        var command = new CreateLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1"),
                PostId = postId
            }
        };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 201);
    }
    

    [HttpDelete("{postId:int}")]
    public async Task<IActionResult> RemoveLike(int postId)
    {
        var command = new DeleteLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader")?.Value ?? "-1"),
                PostId = postId
            }
        };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> GetLikes(int postId, [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
        var command = new GetPostLikesQuery(){ Id = postId, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
        var users = await _mediator.Send(command);
        return ResponseHandler<List<UserDto>>.HandleResponse(users, 200);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetLikedPost( [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
        var command = new GetLikedPostRequest(){ Id = int.Parse(User.FindFirst("reader")?.Value ?? "-1"), PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
        var posts = await _mediator.Send(command);
        return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    }
}