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
    public async Task<ActionResult> AddLike( int PostId)
    {
        var command = new CreateLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader").Value),
                PostId = PostId
            }
        };
        await _mediator.Send(command);
        return NoContent();
    }
    

    [HttpDelete("{PostId}")]
    public async Task<ActionResult> RemoveLike(int PostId)
    {
        var command = new DeleteLikeCommand(){
            like = new LikedDto{
                UserId = int.Parse(User.FindFirst("reader").Value),
                PostId = PostId
            }
        };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{PostId}")]
    public async Task<ActionResult<List<UserDto>>> GetLikes(int PostId){
        var command = new GetPostLikesQuery(){ Id = PostId };
        var users = await _mediator.Send(command);
        return Ok(users);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<PostDto>>> GetLikedPost(){
        var command = new GetLikedPostRequest(){ Id = int.Parse(User.FindFirst("reader").Value) };
        var posts = await _mediator.Send(command);
        return Ok(posts);
    }

    



}