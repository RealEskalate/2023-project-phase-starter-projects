using Application.DTO.Common;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Requests.Commands;
using Application.Features.PostFeature.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("post/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostResponseDTO>>> Get()
        {
            var userId = 3;
            var result = await _mediator.Send(new GetAllPostsQuery { userId = userId});
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostResponseDTO>> Get(int id)
        {
            var userId = 3;
            var result = await _mediator.Send(new GetSinglePostQuery { Id = id, userId = userId });

            return result;
        }


        [HttpPost]
        public async Task<ActionResult<PostResponseDTO>> Post([FromBody] PostCreateDTO newPostData)
        {
            var userId = 3;
            var result = await _mediator.Send(new CreatePostCommand{ NewPostData = newPostData, userId = userId });
            return Ok(result);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<PostResponseDTO>> Put(int id, [FromBody] PostUpdateDTO UpdatePostData)
        {
            var userId = 3;
            var result = await _mediator.Send(new UpdatePostCommand { Id = id, PostUpdateData = UpdatePostData , userId = userId });
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponseDTO>> Delete(int id)
        {
            var userId = 3;
            var result = await _mediator.Send(new DeletePostCommand { userId = userId, Id = id });
            return Ok(result);
        }
    }
}
