using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Posts.Requests.Commands;
using SocialSync.Application.Features.Posts.Requests.Queries;
using SocialSync.Application.DTOs.PostDtos;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/posts")]
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
            var getAllRequest = new GetAllPostsRequest();
            var posts = await _mediator.Send(getAllRequest);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var getPostByIdRequest = new GetPostByIdRequest(id);
            var post = await _mediator.Send(getPostByIdRequest);
            return Ok(post);
        }

        [HttpPost]
        [Route("/posts/create")]
        public async Task<IActionResult> Create2([FromBody] CreatePostDto createPostDto)
        {
            var createCommand = new CreatePostCommand(createPostDto);
            var response = await _mediator.Send(createCommand);
            if(response.IsSuccess)
            {
                return CreatedAtAction(nameof(Get), new { id = response.Value }, response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPatch]
        [Route("/posts/edit")]
        public async Task<IActionResult> Update([FromBody] UpdatePostDto updatePostDto)
        {
            var updateCommand = new UpdatePostCommand(updatePostDto);
            var response = await _mediator.Send(updateCommand);

            if (response.IsSuccess){
                return Ok();
            }
            else{
                return BadRequest(response.Message);
            }
        }

        [HttpGet]
        [Route("/posts/by/{userId}")]
        public async Task<IActionResult> GetByAuthor(int userId)
        {
            var getByAuthorRequest = new GetPostsByUserIdRequest(userId);
            var response = await _mediator.Send(getByAuthorRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("/posts/tags/")]
        public async Task<IActionResult> GetByTags([FromQuery] List<string> tags)
        {
            var getByTagsRequest = new GetPostsByTagsRequest(tags);
            var response = await _mediator.Send(getByTagsRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("/posts/delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var removePostDto = new RemovePostDto{
                                        Id = id,
                                        UserId = 1
                                    };
            var deletePostCommand = new RemovePostCommand(removePostDto);
            var response = await _mediator.Send(deletePostCommand);
            if(response.IsSuccess)
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
