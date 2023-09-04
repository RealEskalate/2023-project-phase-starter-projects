using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Application.DTOs.PostDtos;
using SocialSync.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public PostsController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllRequest = new GetAllPostsRequest();
            var response = await _mediator.Send(getAllRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPostByIdRequest = new GetPostByIdRequest { Id = id };
            var response = await _mediator.Send(getPostByIdRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePostAsync([FromBody] String content )
        {
            
            int userId = _userService.GetUserId();
            CreatePostDto createPostDto = new()
            {
                UserId  = userId,
                Content = content
            };
            var createCommand = new CreatePostCommand { CreatePostDto = createPostDto };
            var response = await _mediator.Send(createCommand);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { id = response }, response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] string content)
        {
            int userId = _userService.GetUserId();
            var updatePostDto = new UpdatePostDto{ Id = id, UserId = userId, Content = content };
            var updateCommand = new UpdatePostCommand { UpdatePostDto = updatePostDto };
            var response = await _mediator.Send(updateCommand);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("user-posts/{userId}")]
        public async Task<IActionResult> GetByAuthorAsync(int userId)
        {
            var getByAuthorRequest = new GetPostsByUserIdRequest { UserId = userId };
            var response = await _mediator.Send(getByAuthorRequest);
            return Ok(response);
        }

        [HttpGet("tags")]
        public async Task<IActionResult> GetByTagsAsync([FromQuery] List<string> tags)
        {
            var getByTagsRequest = new GetPostsByTagsRequest { Tags = tags };
            var response = await _mediator.Send(getByTagsRequest);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int userId = _userService.GetUserId();
            var deletePostDto = new DeletePostDto
            {
                Id = id,
                UserId = userId
            };
            var deletePostCommand = new DeletePostCommand { DeletePostDto = deletePostDto };
            var response = await _mediator.Send(deletePostCommand);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
