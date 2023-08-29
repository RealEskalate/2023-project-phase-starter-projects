using Application.DTO.CommentDTO;
using Application.DTO.Like;
using Application.DTO.Post;
using Application.DTO.UserDTO;
using Application.Features.Comment.Requests.Commands;
using Application.Features.Comment.Requests.Queries;
using Application.Features.Like.Request.Commands;
using Application.Features.Like.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    
  
    [HttpPost("{PostId}")]
    public async Task<IActionResult> AddLike( int PostId)
    {
        var command = new CreateLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader").Value),
                PostId = PostId
            }
        };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 201);
    }
    

    [HttpDelete("{PostId}")]
    public async Task<IActionResult> RemoveLike(int PostId)
    {
        var command = new DeleteLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader").Value),
                PostId = PostId
            }
        };
        var result = await _mediator.Send(command);
        return ResponseHandler<Unit>.HandleResponse(result, 204);
    }

    [HttpGet("{PostId}")]
    public async Task<IActionResult> GetLikes(int PostId){
        var command = new GetPostLikesQuery(){ Id = PostId };
        var users = await _mediator.Send(command);
        return ResponseHandler<List<UserDto>>.HandleResponse(users, 200);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetLikedPost(){
        var command = new GetLikedPostRequest(){ Id = int.Parse(User.FindFirst("reader").Value) };
        var posts = await _mediator.Send(command);
        return ResponseHandler<List<PostDto>>.HandleResponse(posts, 200);
    }

    



}