using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Application.DTOs.PostDtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllRequest = new GetAllPostsRequest();
            var posts = await _mediator.Send(getAllRequest);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPostByIdRequest = new GetPostByIdRequest { Id = id };
            var post = await _mediator.Send(getPostByIdRequest);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody] CreatePostDto createPostDto)
        {
            var createCommand = new CreatePostCommand { CreatePostDto = createPostDto };
            var response = await _mediator.Send(createCommand);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { id = response.Value }, response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdatePostDto updatePostDto)
        {
            var updateCommand = new UpdatePostCommand { UpdatePostDto = updatePostDto };
            var response = await _mediator.Send(updateCommand);

            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            var deletePostDto = new DeletePostDto
            {
                Id = id,
                UserId = 1
            };
            var deletePostCommand = new DeletePostCommand { DeletePostDto = deletePostDto };
            var response = await _mediator.Send(deletePostCommand);
            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
