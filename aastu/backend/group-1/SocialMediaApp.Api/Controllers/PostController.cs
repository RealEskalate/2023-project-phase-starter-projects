using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.DTOs.Views;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IHttpContextAccessor _contextAccessor;

        public PostController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> Get()
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

            var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = new Guid(Id)});

            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PostDto>> Get(Guid id)
        {
            var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");


            var post = await _mediator.Send(new GetPostRequestById{Id=id, UserID = new Guid(userId)});
            if(post != null)
            {
                post.Comments = await _mediator.Send(new GetCommentListRequest { Id = id });
            }
            return Ok(post);
        }  

        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostView postView)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");


            CreatePostDto post = new CreatePostDto()
            {
                UserId = new Guid(Id),
                Content = postView.Content,
                Title = postView.Title,
                HashTag = postView.HashTag,
            };

            var command = new CreatePostsCommand { postDto = post };
            var response = await _mediator.Send(command);
            if(response.Success == true)
            {
                var followers = await _mediator.Send(new GetFollowerRequest { userId = post.UserId });
                var user = await _mediator.Send(new GetUserRequest { Id = post.UserId });
                var notificationDto = new CreateNotificationDto();

                notificationDto.IsRead = false;
                notificationDto.Content = $"{user.Name} posted {post.Title}";
                foreach (var follower in followers)
                {
                    notificationDto.UserId = follower.CurrentUser;
                    var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                    await _mediator.Send(notificationCommand);
                }

            }
            return Ok(response);
        }

        // PUT api/<PostController>/5
        [HttpPut]
        public async Task<ActionResult>  UpdatePost([FromBody] UpdatePostView post )
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

            UpdatePostDto posts = new UpdatePostDto()
            {
                UserId = new Guid(Id),
                Title = post.Title,
                HashTag = post.HashTag,
                Content = post.Content,
                Id = post.PostId,
            };
            var command = new UpdatePostsCommand {post = posts };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<PostController>/5 
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

            await _mediator.Send(new DeletePostCommand { Id  =id, UserId = new Guid(Id)});
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<PostDto>>> SearchPosts(string query)
        {
            var posts = await _mediator.Send(new SearchPostRequest{query = query});

            return posts;
        }
    }
}
